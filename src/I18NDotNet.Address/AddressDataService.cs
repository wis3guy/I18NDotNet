using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	public sealed class AddressDataService : GoogleI18NServiceBase
	{
		private const string BasePath = "address/data";

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

		public async Task<IDictionary<string, string>> GetAddressDataAsync(AddressDataKey builder)
		{
			var key = builder.ToString();
			var data = _cache.Get(key);

			if (data != null)
				return data;

			var path = $"{BasePath}/{builder}";

			data = await GetJsonResponseAsDictionaryAsync(path);

			_cache.Add(key, data);

			return data;
		}

		public bool SupportsCountry(string countryCode)
		{
			return RegionDataConstants.ContainsKey(countryCode);
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