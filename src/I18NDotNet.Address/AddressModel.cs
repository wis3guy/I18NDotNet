using System.Collections.Generic;

namespace I18N.Address
{
	public class AddressModel
	{
		public AddressModel(Country country)
		{
			AddressLine = new List<string>();
			Country = country;
		}

		public string Name { get; set; }
		public string Organisation { get; set; }
		public List<string> AddressLine { get; }
		public string City { get; set; }
		public string DependentLocality { get; set; }
		public string AdministrativeArea { get; set; }
		public string PostalCode { get; set; }
		public string SortingCode { get; set; }
		public Country Country { get; }
	}
}