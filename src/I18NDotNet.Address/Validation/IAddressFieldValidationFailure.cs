namespace I18N.Address.Validation
{
	public interface IAddressFieldValidationFailure
	{
		AddressFieldKey Key { get; }
		ValidationFailureReason Reason { get; }
	}
}