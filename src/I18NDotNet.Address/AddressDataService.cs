using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	public sealed class AddressDataService : GoogleI18NServiceBase
	{
		private const string BasePath = "address/data";
		private const string DefaultsKey = "ZZ";

		private static readonly RegionDataConstants Constants = new RegionDataConstants();

		private readonly IAddressDataCache _cache;

		public AddressDataService()
		{
			_cache = new DummyAddressDataCache();
		}

		public AddressDataService(IAddressDataCache cache)
		{
			if (cache == null) throw new ArgumentNullException(nameof(cache));

			_cache = cache;
		}

		internal AddressData Defaults => Constants[DefaultsKey];

		internal async Task<AddressData> GetAddressDataAsync(AddressDataKeyBuilder builder)
		{
			var key = builder.ToString();
			var data = _cache.Get(key);

			if (data != null)
				return new AddressData(data);

			var path = $"{BasePath}/{builder}";

			data = await GetJsonResponseAsDictionaryAsync(path);

			_cache.Add(key, data);

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

		private class DummyAddressDataCache : IAddressDataCache
		{
			public void Add(string key, IDictionary<string, string> data)
			{
			}

			public IDictionary<string, string> Get(string key)
			{
				return null;
			}
		}
	}
}