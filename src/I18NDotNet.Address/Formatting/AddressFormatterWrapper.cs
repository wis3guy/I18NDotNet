using System;
using System.Threading.Tasks;

namespace I18N.Address.Formatting
{
	internal class AddressFormatterWrapper // for lack of a better name :-S
	{
		private readonly AddressDataService _service;

		public AddressFormatterWrapper(AddressDataService service)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));

			_service = service;
		}

		public async Task<string> FormatAsync(IAddress model, IAddressFormatter formatter)
		{
			if (model == null) throw new ArgumentNullException(nameof(model));
			if (formatter == null) throw new ArgumentNullException(nameof(formatter));

			var data = await GetDataAsync(model);

			var country = data[AddressDataContext.Country][AddressData.Properties.Name];
			var format = data[AddressData.Properties.Format];

			return formatter.Format(model, country, format);
		}

		private async Task<AddressData> GetDataAsync(IAddress address)
		{
			var model = new Address(address);
			var data = new AddressData();

			if (RegionDataConstants.ContainsCountry(model.CountryCode))
			{
				var dataKey = new AddressDataKey(model.CountryCode);

				data.Refine(dataKey,RegionDataConstants.Get(dataKey));

				if (data.ContainsLanguage(model.LanguageCode))
				{
					dataKey.SetLanguage(model.LanguageCode);
					data.Refine(dataKey, await _service.GetAddressDataValuesAsync(dataKey));
				}

				var input = model.GetCleanValue(AddressFieldKey.S); // administrative area

				if (input != null)
				{
					var subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input, AddressDataContext.Country);

					if (subRegionKey != null)
					{
						dataKey.Append(subRegionKey);
						data.Refine(dataKey, await _service.GetAddressDataValuesAsync(dataKey));

						input = model.GetCleanValue(AddressFieldKey.C); // locality

						if (input != null)
						{
							subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input, AddressDataContext.AdministrativeArea);

							if (subRegionKey != null)
							{
								dataKey.Append(subRegionKey);
								data.Refine(dataKey, await _service.GetAddressDataValuesAsync(dataKey));

								input = model.GetCleanValue(AddressFieldKey.D); // dependent locality

								if (input != null)
								{
									subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input, AddressDataContext.Locality);

									if (subRegionKey != null)
									{
										dataKey.Append(subRegionKey);
										data.Refine(dataKey, await _service.GetAddressDataValuesAsync(dataKey));
									}
								}
							}
						}
					}
				}
			}

			return data;
		}
	}
}