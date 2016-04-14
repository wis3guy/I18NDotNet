using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public class AddressModel : IAddress
	{
		public AddressModel()
		{
			Fields = new AddressFieldModel[0];
			SelectItems = new SelectItemsModel();
		}

		public AddressFieldModel[] Fields { get; set; }
		public SelectItemsModel SelectItems { get; set; }
		
		public string Name { get; set; }
		public string Organisation { get; set; }
		public string[] AddressLine { get; set; }
		public string Locality { get; set; }
		public string DependentLocality { get; set; }
		public string AdministrativeArea { get; set; }
		public string PostalCode { get; set; }
		public string SortingCode { get; set; }
		public string CountryCode { get; set; }
		public string LanguageCode { get; set; }
	}
}