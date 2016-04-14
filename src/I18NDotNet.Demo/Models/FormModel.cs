using I18NDotNet.Address.Mvc;

namespace I18NDotNet.Demo.Models
{
	public class FormModel
	{
		public AddressModel VisitAddress { get; set; }
		public string VisitAddressHtmlFormatted { get; set; }
		public string VisitAddressStringFormatted { get; set; }

		public AddressModel PostalAddress { get; set; }
		public string PostalAddressHtmlFormatted { get; set; }
		public string PostalAddressStringFormatted { get; set; }

	}
}