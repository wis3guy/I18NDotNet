using System.Threading.Tasks;

namespace I18N.Address
{
	public sealed class AddressDataService : GoogleI18NServiceBase
	{
		private const string BasePath = "address/data";
		private const string DefaultsKey = "ZZ";

		private static readonly RegionDataConstants Constants = new RegionDataConstants();

		internal AddressData Defaults => Constants[DefaultsKey];

		internal async Task<AddressData> GetAddressDataAsync(AddressDataKeyBuilder builder)
		{
			var path = $"{BasePath}/{builder}";
			var data = await GetJsonResponseAsDictionary(path);

			return new AddressData(data);
		}

		internal bool SupportsCountry(Country country)
		{
			return Constants.ContainsKey(country.Code);
		}

		internal AddressData GetCountryDefaults(Country country)
		{
			return Constants[country.Code];
		}
	}
}