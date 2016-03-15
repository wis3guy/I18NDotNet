namespace I18N.Address.Validation
{
	public interface IAddressFieldValidationResult
	{
		bool IsValid { get; }
		AddressFieldKey Key { get; }
		ValidationFailureReason Reason { get; }
	}
}