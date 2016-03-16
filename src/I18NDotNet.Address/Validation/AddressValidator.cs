using System;
using System.Linq;
using System.Threading.Tasks;

namespace I18N.Address.Validation
{
	internal class AddressValidator
	{
		private readonly AddressDataService _addressDataService;
		private readonly AddressFieldKey[] _allKeys;

		public AddressValidator(AddressDataService addressDataService)
		{
			if (addressDataService == null)
				throw new ArgumentNullException(nameof(addressDataService));

			_addressDataService = addressDataService;
			_allKeys = Enum.GetValues(typeof(AddressFieldKey)).Cast<AddressFieldKey>().ToArray();
		}

		public async Task<IAddressValidationResult> ValidateAsync(AddressModel model)
		{
			var result = new AddressValidationResult();
			var data = _addressDataService.Defaults;

			//
			// Country
			
			if (!_addressDataService.SupportsCountry(model.Country))
			{
				result.Add(new AddressFieldValidationFailure(AddressFieldKey.Country, ValidationFailureReason.Uknown));
			}
			else
			{
				var dataKey = new AddressDataKeyBuilder(model.Country);
				data.Refine(_addressDataService.GetCountryDefaults(model.Country));

				//
				// Language

				if (model.Language.HasValue)
				{
					if (!data.IsSupportedLanguage(model.Language.Value))
					{
						result.Add(new AddressFieldValidationFailure(AddressFieldKey.Language, ValidationFailureReason.Uknown));
					}
					else
					{
						dataKey.SetLanguage(model.Language.Value);
						data.Refine(await _addressDataService.GetAddressDataAsync(dataKey));
					}
				}

				if (!result.Any())
				{
					//
					// Administrative area

					var input = model.GetCleanValue(AddressFieldKey.S);

					if (input != null)
					{
						var subRegionKey = data.GetSubRegionKeyForInputValue(input);

						if (subRegionKey == null)
						{
							result.Add(new AddressFieldValidationFailure(AddressFieldKey.S, ValidationFailureReason.Uknown));
						}
						else
						{
							dataKey.Append(subRegionKey);
							data.Refine(await _addressDataService.GetAddressDataAsync(dataKey));

							//
							// Locality

							input = model.GetCleanValue(AddressFieldKey.C);

							if (input != null)
							{
								subRegionKey = data.GetSubRegionKeyForInputValue(input);

								if (subRegionKey == null)
								{
									result.Add(new AddressFieldValidationFailure(AddressFieldKey.C, ValidationFailureReason.Uknown));
								}
								else
								{
									dataKey.Append(subRegionKey);
									data.Refine(await _addressDataService.GetAddressDataAsync(dataKey));

									//
									// Sub-locality

									input = model.GetCleanValue(AddressFieldKey.D);

									if (input != null)
									{
										subRegionKey = data.GetSubRegionKeyForInputValue(input);

										if (subRegionKey == null)
										{
											result.Add(new AddressFieldValidationFailure(AddressFieldKey.D, ValidationFailureReason.Uknown));
										}
										else
										{
											dataKey.Append(subRegionKey);
											data.Refine(await _addressDataService.GetAddressDataAsync(dataKey));
										}
									}
								}
							}
						}
					}
				}
			}

			//
			// Zip code

			if (data.ZipRegex != null)
			{
				var input = model.GetCleanValues(AddressFieldKey.Z).Single();

				if (!data.ZipRegex.IsMatch(input))
					result.Add(new AddressFieldValidationFailure(AddressFieldKey.Z, ValidationFailureReason.Invalid));
			}

			//
			// Required fields

			result.AddRange(_allKeys
				.Where(x => data.IsRequiredField(x))
				.Where(x => model.GetCleanValues(x).All(v => v == null))
				.Select(key => new AddressFieldValidationFailure(key, ValidationFailureReason.Required)));

			//
			// Only expected fields

			result.AddRange(_allKeys
				.Where(x => !data.IsExpectedField(x))
				.Where(key => model.GetCleanValues(key).All(v => v != null))
				.Select(key => new AddressFieldValidationFailure(key, ValidationFailureReason.Unexpected)));

			return result;
		}
	}
}