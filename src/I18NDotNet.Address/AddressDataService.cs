using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	public sealed class AddressDataService : GoogleI18NServiceBase
	{
		private const string BasePath = "address/data";
		private const string DefaultCountryCode = "ZZ";
		
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

		public async Task<DEPRICATED_AddressData> GetAddressDataAsync(AddressDataKey builder)
		{
			var key = builder.ToString();
			var data = _cache.Get(key);

			if (data != null)
				return new DEPRICATED_AddressData(data);

			var path = $"{BasePath}/{builder}";

			data = await GetJsonResponseAsDictionaryAsync(path);

			_cache.Add(key, data);

			return new DEPRICATED_AddressData(data);
		}

		public bool SupportsCountry(string countryCode)
		{
			return RegionDataConstants.ContainsKey(countryCode);
		}

		internal DEPRICATED_AddressData GetCountryDefaults(Country country)
		{
			return GetCountryDefaults(country.Code);
		}

		internal DEPRICATED_AddressData GetCountryDefaults(string key = null)
		{
			var data = _cache.Get(key ?? DefaultCountryCode);

			if (data != null)
				return new DEPRICATED_AddressData(data);

			data = RegionDataConstants.Get(DefaultCountryCode);

			_cache.Add(key, data);

			return new DEPRICATED_AddressData(data);
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