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

			var tuple = await GetMostSpecificDataAsync(model);

			return formatter.Format(model, tuple.Item1, tuple.Item2.Format);
		}

		private async Task<Tuple<string, DEPRICATED_AddressData>> GetMostSpecificDataAsync(IAddress address)
		{
			var model = new KeyedAddress(address);
			string country = null;
			var data = _service.GetCountryDefaults();

			if (_service.SupportsCountry(model.CountryCode))
			{
				var dataKey = new AddressDataKey(model.CountryCode);

				data = _service.GetCountryDefaults(model.CountryCode);

				if (data.IsSupportedLanguage(model.LanguageCode))
				{
					dataKey.SetLanguage(model.LanguageCode);
					data.Refine(await _service.GetAddressDataAsync(dataKey));
				}

				country = data.Name;

				var input = model.GetCleanValue(AddressFieldKey.S); // administrative area

				if (input != null)
				{
					var subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input);

					if (subRegionKey != null)
					{
						dataKey.Append(subRegionKey);
						data.Refine(await _service.GetAddressDataAsync(dataKey));

						input = model.GetCleanValue(AddressFieldKey.C); // locality

						if (input != null)
						{
							subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input);

							if (subRegionKey != null)
							{
								dataKey.Append(subRegionKey);
								data.Refine(await _service.GetAddressDataAsync(dataKey));

								input = model.GetCleanValue(AddressFieldKey.D); // dependent locality

								if (input != null)
								{
									subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input);

									if (subRegionKey != null)
									{
										dataKey.Append(subRegionKey);
										data.Refine(await _service.GetAddressDataAsync(dataKey));
									}
								}
							}
						}
					}
				}
			}

			return new Tuple<string, DEPRICATED_AddressData>(country, data);
		}
	}
}