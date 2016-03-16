using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	internal class AddressDataService : GoogleI18NServiceBase, IAddressDataService
	{
		private const string BasePath = "address/data";
		private const string DefaultsKey = "ZZ";

		private AddressDataService()
		{
			// avoid direct creation and enforce factory(method) usage ...
		}

		public static AddressDataService Create(HashSet<string> countries, AddressData defaults)
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

			var response = await service.GetTypedResponse<Dictionary<string, string>>(BasePath);

			service.Countries = new HashSet<string>(response["countries"].Split('~'));
			service.Defaults = await service.GetTypedResponse<AddressData>($"{BasePath}/{DefaultsKey}");

			return service;
		}

		public HashSet<string> Countries { get; private set; }
		public AddressData Defaults { get; private set; }

		public async Task<AddressData> GetAddressDataAsync(AddressDataKeyBuilder builder)
		{
			var path = $"{BasePath}/{builder}";
			var data = await GetTypedResponse<Dictionary<string, string>>(path);

			return new AddressData(data);
		}

		public bool SupportsCountry(Country country)
		{
			return Countries.Contains(country.Code);
		}
	}
}