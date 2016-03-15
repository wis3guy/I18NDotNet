namespace I18N.Address.Validation
{
	internal class AddressFieldValidationResult : IAddressFieldValidationResult
	{
		public AddressFieldValidationResult(AddressFieldKey key)
		{
			Key = key;
		}

		public bool IsValid => Reason == ValidationFailureReason.None;
		public AddressFieldKey Key { get; }
		public ValidationFailureReason Reason { get; set; }
	}
}