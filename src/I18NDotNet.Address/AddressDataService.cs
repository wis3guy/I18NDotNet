using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	public sealed class AddressDataService : GoogleI18NServiceBase
	{
		private const string BasePath = "address/data";
		private const string DefaultsKey = "ZZ";

		private AddressDataService()
		{
			// avoid direct creation and enforce factory(method) usage ...
		}

		internal static AddressDataService Create(HashSet<string> countries, AddressData defaults)
		{
			return new AddressDataService
			{
				Countries = countries,
				Defaults = defaults
			};
		}

		internal static async Task<AddressDataService> CreateAndInitializeAsync()
		{
			var service = new AddressDataService();

			var response = await service.GetTypedResponse<Dictionary<string, string>>(BasePath);

			service.Countries = new HashSet<string>(response["countries"].Split('~'));
			service.Defaults = await service.GetTypedResponse<AddressData>($"{BasePath}/{DefaultsKey}");

			return service;
		}

		internal HashSet<string> Countries { get; private set; }
		internal AddressData Defaults { get; private set; }

		internal async Task<AddressData> GetAddressDataAsync(AddressDataKeyBuilder builder)
		{
			var path = $"{BasePath}/{builder}";
			var data = await GetTypedResponse<Dictionary<string, string>>(path);

			return new AddressData(data);
		}

		internal bool SupportsCountry(Country country)
		{
			return Countries.Contains(country.Code);
		}
	}
}