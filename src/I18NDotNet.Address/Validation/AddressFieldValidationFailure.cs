namespace I18N.Address.Validation
{
	internal class AddressFieldValidationFailure : IAddressFieldValidationFailure
	{
		public AddressFieldValidationFailure(AddressFieldKey key, ValidationFailureReason reason)
		{
			Key = key;
			Reason = reason;
		}

		public AddressFieldKey Key { get; }
		public ValidationFailureReason Reason { get; }
	}
}