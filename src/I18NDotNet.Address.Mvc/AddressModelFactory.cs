using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public class AddressModelFactory
	{
		private static readonly Regex FormatFieldRegex = new Regex(@"%([A-Z])\b");

		public async Task<AddressModel> CreateAsync(AddressDataService service, IAddress current)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (current == null) throw new ArgumentNullException(nameof(current));

			var data = await service.GetAddressDataAsync(current.CountryCode, current.LanguageCode, current.AdministrativeArea, current.Locality, current.DependentLocality);

			var model = new AddressModel
			{
				CountryCode = current.CountryCode,
				LanguageCode = current.LanguageCode,

				AdministrativeArea = current.AdministrativeArea,
				AddressLine = current.AddressLine,
				Locality = current.Locality,
				Name = current.Name,
				Organisation = current.Organisation,
				DependentLocality = current.DependentLocality,
				PostalCode = current.PostalCode,
				SortingCode = current.SortingCode,
				
				SelectItems = data.GetSelectItems()
			};

			model.Fields = GetFields(data, model.SelectItems);

			if (!model.SelectItems.AdministrativeArea.Any())
				return model;

			model.AdministrativeArea = data.GetSubRegionKeyForInputValue(model.LanguageCode, model.AdministrativeArea, AddressDataContext.Country);

			if (!model.SelectItems.Locality.Any())
				return model;

			model.Locality = data.GetSubRegionKeyForInputValue(model.LanguageCode, model.Locality, AddressDataContext.AdministrativeArea);

			if (!model.SelectItems.DependentLocality.Any())
				return model;

			model.DependentLocality = data.GetSubRegionKeyForInputValue(model.LanguageCode, model.DependentLocality, AddressDataContext.Locality);

			return model;
		}

		public async Task<AddressModel> CreateAsync(AddressDataService service, CultureInfo culture)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (culture == null) throw new ArgumentNullException(nameof(culture));

			var region = new RegionInfo(culture.LCID);
			var data = await service.GetAddressDataAsync(region.TwoLetterISORegionName, culture.TwoLetterISOLanguageName);

			var model = new AddressModel
			{
				CountryCode = region.TwoLetterISORegionName,
				LanguageCode = culture.TwoLetterISOLanguageName,

				SelectItems = data.GetSelectItems()
			};

			model.Fields = GetFields(data, model.SelectItems); // TODO: Seems broken

			return model;
		}

		private static AddressFieldModel[] GetFields(AddressData data, SelectItemsModel selectItems)
		{
			if (!data.ContainsKey(AddressData.Properties.Format))
				return new AddressFieldModel[0];

			var result = new List<AddressFieldModel>();

			var format = FormatFieldRegex.Matches(data[AddressData.Properties.Format])
				.Cast<Match>()
				.Select(match => match.Groups[1].Value)
				.ToArray();
			
			foreach (var field in format)
			{
				AddressFieldKey parsed;

				if (Enum.TryParse(field, out parsed))
					result.Add(new AddressFieldModel {Field = parsed});
			}

			if (!data.ContainsKey(AddressData.Properties.Format))
			{
				var required = data[AddressData.Properties.RequiredFields].ToCharArray().Select(x => x.ToString()).ToArray();

				foreach (var field in required)
				{
					AddressFieldKey parsed;

					if (!Enum.TryParse(field, out parsed))
						continue;

					foreach (var fieldModel in result.Where(x => x.Field == parsed))
						fieldModel.Required = true;
				}
			}


			if (selectItems.AdministrativeArea.Any() &&
			    result.All(x => x.Field != AddressFieldKey.S))
				result.Add(new AddressFieldModel {Field = AddressFieldKey.S});

			if (selectItems.Locality.Any() &&
				result.All(x => x.Field != AddressFieldKey.C))
				result.Add(new AddressFieldModel { Field = AddressFieldKey.C });

			if (selectItems.DependentLocality.Any() &&
				result.All(x => x.Field != AddressFieldKey.D))
				result.Add(new AddressFieldModel { Field = AddressFieldKey.D });

			return result.ToArray();
		}
	}
}