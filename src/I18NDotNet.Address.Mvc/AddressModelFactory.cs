using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
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

			model.Fields = data.GetFields(model.SelectItems);

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

			model.Fields = data.GetFields(model.SelectItems); // TODO: Seems broken

			return model;
		}
	}
}