using System;
using System.Threading.Tasks;

namespace I18N.Address
{
	public interface IAddressDataService : IDisposable
	{
		Task<AddressDataResponse> GetAddressDataAsync(Country country);
		bool SupportsCountry(Country country);
	}
}