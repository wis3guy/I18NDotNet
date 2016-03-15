using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	internal class AddressDataService : GoogleI18NService, IAddressDataService
	{
		private HashSet<string> _countries;
		private AddressDataResponse _defaults;

		public async Task InitializeAsync()
		{
			var response = await GetTypedResponse<DataResponse>("address/data");

			_countries = new HashSet<string>(response.Countries.Split('~'));
			_defaults = await GetTypedResponse<AddressDataResponse>("address/data/ZZ");
		}

		public async Task<AddressDataResponse> GetAddressDataAsync(Country country)
		{
			if (!SupportsCountry(country))
				throw new ArgumentException($"Unknown country code: {country.Code}", nameof(country));

			var response = await GetTypedResponse<AddressDataResponse>($"address/data/{country.Code}");

			response.ApplyDefaults(_defaults);

			return response;
		}

		public bool SupportsCountry(Country country)
		{
			return _countries.Contains(country.Code);
		}
	}
}