using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	public interface IAddressDataService : IDisposable
	{
		HashSet<string> Countries { get; }
		AddressData Defaults { get; }
		Task<AddressData> GetAddressDataAsync(AddressDataKeyBuilder builder);
		bool SupportsCountry(Country country);
	}
}