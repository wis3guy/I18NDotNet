namespace I18N.Address.Formatting
{
	public interface IAddressFormatter
	{
		string Format(IAddress model, string country, string format);
	}
}
