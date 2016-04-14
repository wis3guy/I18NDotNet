using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public class AddressModelFactory
	{
		public async Task<AddressModel> CreateAsync(AddressDataService service, IAddress current)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (current == null) throw new ArgumentNullException(nameof(current));

			var data = await service.GetAddressDataAsync(current.CountryCode, current.LanguageCode, current.AdministrativeArea, current.Locality, current.DependentLocality);

			return new AddressModel
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
				
				Fields = GetFields(data),
				SelectItems = data.GetSelectItems()
			};
		}

		public async Task<AddressModel> CreateAsync(AddressDataService service, CultureInfo culture)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (culture == null) throw new ArgumentNullException(nameof(culture));

			var region = new RegionInfo(culture.LCID);
			var data = await service.GetAddressDataAsync(region.TwoLetterISORegionName, culture.TwoLetterISOLanguageName);

			return new AddressModel
			{
				CountryCode = region.TwoLetterISORegionName,
				LanguageCode = culture.TwoLetterISOLanguageName,

				Fields = GetFields(data),
				SelectItems = data.GetSelectItems()
			};
		}

		

		private static AddressFieldModel[] GetFields(AddressData data)
		{
			if (!data.ContainsKey(AddressData.Properties.Format))
				return new AddressFieldModel[0];

			var result = new List<AddressFieldModel>();
			var format = data[AddressData.Properties.Format]
				.Split(new[] {"%n", "%"}, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Substring(0,1))
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

			return result.ToArray();
		}
	}
}