namespace I18N.Address
{
	public interface IAddress
	{
		string Name { get; }
		string Organisation { get; }
		string[] AddressLine { get; }
		string Locality { get; }
		string DependentLocality { get; }
		string AdministrativeArea { get; }
		string PostalCode { get; }
		string SortingCode { get; }
		string CountryCode { get; }
		string LanguageCode { get; }
	}
}