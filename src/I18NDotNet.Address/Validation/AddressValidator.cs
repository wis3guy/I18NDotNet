using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace I18N.Address.Validation
{
	internal class AddressValidator
	{
		private readonly IAddressDataService _addressDataService;
		private readonly AddressFieldKey[] _allKeys;

		public AddressValidator(IAddressDataService addressDataService)
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
			
			if (!_addressDataService.SupportsCountry(model.Country))
				result.Add(new AddressFieldValidationFailure(AddressFieldKey.Country, ValidationFailureReason.Uknown));

			var dataKey = new AddressDataKey(model.Country);

			if (model.Language.HasValue)
				dataKey.SetLanguage(model.Language.Value);

			data.Override(await _addressDataService.GetAddressDataAsync(dataKey));

			var administrativeArea = model.GetCleanValue(AddressFieldKey.S).Single();

			if ((administrativeArea != null) && (data["sub_keys"] != null))
			{
				// todo: assert valid administrative value
				dataKey.SetAdministrativeArea(administrativeArea);
			}

			if (!result.Any())
			{
				data.Override(await _addressDataService.GetAddressDataAsync(dataKey));

				var locality = model.GetCleanValue(AddressFieldKey.C).Single();

				if ((locality != null) && (data["sub_keys"] != null))
				{
					// todo: assert valid locality
				}

				dataKey.SetLocality(locality);
			}

			if (!result.Any())
			{
				data.Override(await _addressDataService.GetAddressDataAsync(dataKey));

				var dependentLocality = model.GetCleanValue(AddressFieldKey.D).Single();

				if ((dependentLocality != null) && (data["sub_keys"] != null))
				{
					// todo: assert valid dependent locality
				}

				dataKey.SetDependentLocality(dependentLocality);
			}

			if (!result.Any())
				data.Override(await _addressDataService.GetAddressDataAsync(dataKey));

			//
			// Required fields

			result.AddRange(_allKeys
				.Where(x => data["require"].Contains($"{x}"))
				.Where(x => model.GetCleanValue(x) == null)
				.Select(key => new AddressFieldValidationFailure(key, ValidationFailureReason.Required)));

			//
			// Only expected fields

			result.AddRange(_allKeys
				.Where(x => !data["fmt"].Contains($"%{x}"))
				.Where(key => model.GetCleanValue(key) != null)
				.Select(key => new AddressFieldValidationFailure(key, ValidationFailureReason.Unexpected)));

			//
			// zip regex

			if (data["zip"] != null)
			{
				var regex = new Regex(data["zip"]);

				if (!regex.IsMatch(model.GetCleanValue(AddressFieldKey.Z).Single()))
					result.Add(new AddressFieldValidationFailure(AddressFieldKey.Z, ValidationFailureReason.Invalid));
			}

			return result;
		}
	}
}