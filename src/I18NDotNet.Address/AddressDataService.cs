using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	internal class AddressDataService : GoogleI18NServiceBase, IAddressDataService
	{
		private AddressDataService()
		{
			// avoid direct creation and enforce factory(method) usage ...
		}

		public static AddressDataService Create(HashSet<string> countries, Dictionary<string, string> defaults)
		{
			return new AddressDataService
			{
				Countries = countries,
				Defaults = defaults
			};
		}

		public static async Task<AddressDataService> CreateAndInitializeAsync()
		{
			var service = new AddressDataService();

			var response = await service.GetTypedResponse<Dictionary<string, string>>("address/data");

			service.Countries = new HashSet<string>(response["countries"].Split('~'));
			service.Defaults = await service.GetTypedResponse<Dictionary<string, string>>("address/data/ZZ");

			return service;
		}

		public HashSet<string> Countries { get; private set; }
		public Dictionary<string, string> Defaults { get; private set; }

		public async Task<Dictionary<string, string>> GetAddressDataAsync(AddressDataKey key)
		{
			var path = $"address/data/{key}";
			return await GetTypedResponse<Dictionary<string, string>>(path);
		}

		public bool SupportsCountry(Country country)
		{
			return Countries.Contains(country.Code);
		}
	}
}