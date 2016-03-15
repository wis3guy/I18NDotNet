using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	public interface IAddressDataService : IDisposable
	{
		HashSet<string> Countries { get; }
		Dictionary<string, string> Defaults { get; }
		Task<Dictionary<string, string>> GetAddressDataAsync(AddressDataKey key);
		bool SupportsCountry(Country country);
	}
}