using System.Threading.Tasks;

namespace I18N.Address
{
	public class AddressDataServiceFactory
	{
		public async Task<IAddressDataService> CreateAsync()
		{
			var service = new AddressDataService();

			await service.InitializeAsync();

			return service;
		}
	}
}