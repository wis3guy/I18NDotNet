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

		public async Task<string> FormatAsync(AddressModel model, IAddressFormatter formatter)
		{
			if (model == null) throw new ArgumentNullException(nameof(model));
			if (formatter == null) throw new ArgumentNullException(nameof(formatter));

			var tuple = await GetMostSpecificDataAsync(model);

			return formatter.Format(model, tuple.Item1, tuple.Item2.Format);
		}

		private async Task<Tuple<string, AddressData>> GetMostSpecificDataAsync(AddressModel model)
		{
			string country = null;
			var data = _service.Defaults;

			if (_service.SupportsCountry(model.Country))
			{
				var dataKey = new AddressDataKeyBuilder(model.Country);

				data = _service.GetCountryDefaults(model.Country);

				if (data.IsSupportedLanguage(model.Language))
				{
					dataKey.SetLanguage(model.Language);
					data.Refine(await _service.GetAddressDataAsync(dataKey));
				}

				country = data.Name;

				var input = model.GetCleanValue(AddressFieldKey.S); // administrative area

				if (input != null)
				{
					var subRegionKey = data.GetSubRegionKeyForInputValue(model.Language, input);

					if (subRegionKey != null)
					{
						dataKey.Append(subRegionKey);
						data.Refine(await _service.GetAddressDataAsync(dataKey));

						input = model.GetCleanValue(AddressFieldKey.C); // locality

						if (input != null)
						{
							subRegionKey = data.GetSubRegionKeyForInputValue(model.Language, input);

							if (subRegionKey != null)
							{
								dataKey.Append(subRegionKey);
								data.Refine(await _service.GetAddressDataAsync(dataKey));

								input = model.GetCleanValue(AddressFieldKey.D); // dependent locality

								if (input != null)
								{
									subRegionKey = data.GetSubRegionKeyForInputValue(model.Language, input);

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

			return new Tuple<string, AddressData>(country, data);
		}
	}
}