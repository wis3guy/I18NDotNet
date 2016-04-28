using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public class I18NController : Controller
	{
		[HttpPost]
		public async Task<ActionResult> Address(AddressModel model, string htmlFieldPrefix, string trigger, string[] select)
		{
			var countryField = $"{htmlFieldPrefix}.CountryCode";
			var administrativeAreaField = $"{htmlFieldPrefix}.AdministrativeArea";
			var localityField = $"{htmlFieldPrefix}.Locality";

			if (trigger.Equals(countryField, StringComparison.OrdinalIgnoreCase))
			{
				if (select.Any(x => x == administrativeAreaField))
					model.AdministrativeArea = null;

				if (select.Any(x => x == localityField))
					model.Locality = null;
			}
			else if (trigger.Equals(administrativeAreaField, StringComparison.OrdinalIgnoreCase))
			{
				if (select.Any(x => x == localityField))
					model.Locality = null;
			}

			using (var service = new AddressDataService())
			{
				var factory = new AddressModelFactory();
				var updated = await factory.CreateAsync(service, model);

				ViewBag.HtmlFieldPrefix = htmlFieldPrefix;

				return View("~/Views/Shared/EditorTemplates/AddressModel.cshtml", updated);
			}
		}
	}
}