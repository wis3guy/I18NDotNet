using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace I18N.Address.Validation
{
	internal class AddressValidator
	{
		private readonly AddressDataResponse _addressData;

		public AddressValidator(AddressDataResponse addressData)
		{
			if (addressData == null)
				throw new ArgumentNullException(nameof(addressData));

			_addressData = addressData;
		}

		public IAddressValidationResult Validate(AddressModel model)
		{
			var required = _addressData.Require
				.ToCharArray()
				.Select(x => (AddressFieldKey) Enum.Parse(typeof (AddressFieldKey), x.ToString()))
				.ToArray();

			var result = Enum.GetValues(typeof (AddressFieldKey))
				.Cast<AddressFieldKey>()
				.Select(key => ValidateField(key, required, model.GetCleanValue(key)));

			return new AddressValidationResult(result);
		}

		private AddressFieldValidationResult ValidateField(AddressFieldKey key, AddressFieldKey[] required, string[] value)
		{
			var result = new AddressFieldValidationResult(key);

			if (required.Any(x => x == key) && value.Any(x => x == null))
				result.Reason = ValidationFailureReason.Required; // required but null

			if ((key == AddressFieldKey.Z) && (_addressData.ZipRegex != null))
			{
				var regex = new Regex(_addressData.ZipRegex);

				if (!regex.IsMatch(value.Single()))
					result.Reason = ValidationFailureReason.InvalidFormat; // regex mismatch
			}

			return result;
		}
	}
}