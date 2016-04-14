﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
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

		public async Task<IAddressValidationResult> ValidateAsync(IAddress address)
		{
			var result = new AddressValidationResult();
			var data = new AddressData();
			var model = new Address(address);

			//
			// Country
			
			if (!_addressDataService.SupportsCountry(model.CountryCode))
			{
				result.Add(new AddressFieldValidationFailure(AddressFieldKey.Country, ValidationFailureReason.Uknown));
			}
			else
			{
				var dataKey = new AddressDataKey(model.CountryCode);
				data.Refine(dataKey, RegionDataConstants.Get(dataKey));

				//
				// Language

				if (!data.ContainsLanguage(model.LanguageCode))
				{
					result.Add(new AddressFieldValidationFailure(AddressFieldKey.Language, ValidationFailureReason.Uknown));
				}
				else
				{
					dataKey.SetLanguage(model.LanguageCode);
					data.Refine(dataKey, await _addressDataService.GetAddressDataValuesAsync(dataKey));
				}

				if (!result.Any())
				{
					var input = model.GetCleanValue(AddressFieldKey.S); // administrative area

					if (input != null)
					{
						var subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input);

						if (subRegionKey == null)
						{
							result.Add(new AddressFieldValidationFailure(AddressFieldKey.S, ValidationFailureReason.Uknown));
						}
						else
						{
							dataKey.Append(subRegionKey);
							data.Refine(dataKey, await _addressDataService.GetAddressDataValuesAsync(dataKey));

							input = model.GetCleanValue(AddressFieldKey.C); // locality

							if (input != null)
							{
								subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input);

								if (subRegionKey == null)
								{
									result.Add(new AddressFieldValidationFailure(AddressFieldKey.C, ValidationFailureReason.Uknown));
								}
								else
								{
									dataKey.Append(subRegionKey);
									data.Refine(dataKey, await _addressDataService.GetAddressDataValuesAsync(dataKey));

									input = model.GetCleanValue(AddressFieldKey.D); // dependent locality

									if (input != null)
									{
										subRegionKey = data.GetSubRegionKeyForInputValue(model.LanguageCode, input);

										if (subRegionKey == null)
										{
											result.Add(new AddressFieldValidationFailure(AddressFieldKey.D, ValidationFailureReason.Uknown));
										}
										else
										{
											dataKey.Append(subRegionKey);
											data.Refine(dataKey, await _addressDataService.GetAddressDataValuesAsync(dataKey));
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

			if (data.ContainsKey(AddressData.Properties.ZipRegex))
			{
				var input = model.GetCleanValues(AddressFieldKey.Z).Single();

				if (!data.IsValidPostalCodeField(input))
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