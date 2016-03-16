using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	// TODO: Add a CachingAddressDataServiceFactory so the consumer can choose whether to cache responses or not.

	public class AddressDataServiceFactory
	{
		private HashSet<string> _countries;
		private AddressData _defaults;

		public async Task<AddressDataService> CreateAsync()
		{
			AddressDataService service;

			if ((_countries == null) || (_defaults == null))
			{
				service = await AddressDataService.CreateAndInitializeAsync();

				_countries = service.Countries;
				_defaults = service.Defaults;
			}
			else
			{
				service = AddressDataService.Create(_countries, _defaults);
			}

			return service;
		}
	}
}