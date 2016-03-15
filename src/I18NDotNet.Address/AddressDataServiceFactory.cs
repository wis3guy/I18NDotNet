using System.Collections.Generic;
using System.Threading.Tasks;

namespace I18N.Address
{
	public class AddressDataServiceFactory
	{
		private HashSet<string> _countries;
		private Dictionary<string, string> _defaults;

		public async Task<IAddressDataService> CreateAsync()
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