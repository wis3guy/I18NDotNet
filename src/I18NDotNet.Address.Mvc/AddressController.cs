using System.Threading.Tasks;
using System.Web.Mvc;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public class AddressController : Controller
	{
		[HttpGet]
		public async Task<ActionResult> Candidates(string countryCode, string languageCode, string administrativeArea, string locality)
		{
			using (var service = new AddressDataService())
			{
				var data = await service.GetAddressDataAsync(countryCode, languageCode, administrativeArea, locality);
				var model = data.GetSelectItems();

				return Json(model, JsonRequestBehavior.AllowGet);
			}
		}
	}
}