namespace I18N.Address.Formatting
{
	public interface IAddressFormatter
	{
		string Format(AddressModel model, string country, string format);
	}
}
