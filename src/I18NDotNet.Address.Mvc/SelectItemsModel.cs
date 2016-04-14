using System.Collections.Generic;
using System.Web.Mvc;

namespace I18NDotNet.Address.Mvc
{
	public class SelectItemsModel
	{
		public SelectItemsModel()
		{
			Country = new SelectListItem[0];
			AdministrativeArea = new SelectListItem[0];
			Locality = new SelectListItem[0];
			DependentLocality = new SelectListItem[0];
		}

		public IEnumerable<SelectListItem> Country { get; set; }
		public IEnumerable<SelectListItem> AdministrativeArea { get; set; }
		public IEnumerable<SelectListItem> Locality { get; set; }
		public IEnumerable<SelectListItem> DependentLocality { get; set; }
	}
}