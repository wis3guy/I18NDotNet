using System.Collections.Generic;

namespace I18N.Address
{
	public interface IAddressDataCache
	{
		void Add(string key, IDictionary<string, string> data);
		IDictionary<string, string> Get(string key);
	}
}