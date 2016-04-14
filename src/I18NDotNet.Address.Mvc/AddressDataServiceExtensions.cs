using System;
using System.Threading.Tasks;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public static class AddressDataServiceExtensions
	{
		public static async Task<AddressData> GetAddressDataAsync(this AddressDataService service, string countryCode, string languageCode, string administrativeArea = null, string locality = null, string dependentLocality = null)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (countryCode == null) throw new ArgumentNullException(nameof(countryCode));
			if (languageCode == null) throw new ArgumentNullException(nameof(languageCode));

			var data = new AddressData();

			if (!RegionDataConstants.ContainsCountry(countryCode))
				return data; // just work with the defaults ...

			var key = new AddressDataKey(countryCode);

			data.Refine(key, RegionDataConstants.Get(key));

			if (data.ContainsLanguage(languageCode))
				key.SetLanguage(languageCode); // request localized data ...

			data.Refine(key, await service.GetAddressDataValuesAsync(key));
			
			if (string.IsNullOrEmpty(administrativeArea))
				return data;

			key.Append(administrativeArea);
			data.Refine(key, await service.GetAddressDataValuesAsync(key));

			if (string.IsNullOrEmpty(locality))
				return data;

			key.Append(locality);
			data.Refine(key, await service.GetAddressDataValuesAsync(key));

			if (string.IsNullOrEmpty(dependentLocality))
				return data;

			key.Append(dependentLocality);
			data.Refine(key, await service.GetAddressDataValuesAsync(key));

			return data;
		}
	}
}