using System.Globalization;
using System.Threading.Tasks;
using System.Web.Mvc;
using I18N.Address;
using I18N.Address.Formatting;
using I18NDotNet.Address.Mvc;
using I18NDotNet.Demo.Models;

namespace I18NDotNet.Demo.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public async Task<ActionResult> Index()
		{
			using (var service = new AddressDataService())
			{
				var culture = CultureInfo.CurrentUICulture;
				var factory = new AddressModelFactory();

				var model = new FormModel
				{
					VisitAddress = await factory.CreateAsync(service, new CultureInfo("nl-NL")),
					PostalAddress = await factory.CreateAsync(service, new CultureInfo("it-IT"))
				};

				return View(model);
			}
		}

		[HttpPost]
		public async Task<ActionResult> Index(FormModel model)
		{
			//using (var addressDataService = new AddressDataService())
			//{
			//	var result = await addressDataService.ValidateAsync(model.Address);

			//	if (!result.IsValid)
			//	{
			//		foreach (var failure in result)
			//		{
			//			var key = "???"; // TODO: How to get this key from the enum value?
			//			string message;

			//			switch (failure.Reason)
			//			{
			//				case ValidationFailureReason.Required:
			//					message = $"{key} is required";
			//					break;
			//				case ValidationFailureReason.Invalid:
			//					message = $"{key} has an invalid value";
			//					break;
			//				case ValidationFailureReason.Unexpected:
			//					message = $"{key} has an unexpected value";
			//					break;
			//				case ValidationFailureReason.Uknown:
			//					message = "Unknown data key";
			//					break;
			//				default:
			//					throw new ArgumentOutOfRangeException();
			//			}

			//			ModelState.AddModelError(key, message);
			//		}
			//	}

			//	//model.CountryCandidates = GetCountryCandidates();
			//	//model.LanguageCandidates = GetLanguageCandidates(model.Country);
			//	//model.AdministrativeAreaCandidates = GetAdministrativeAreaCandidates(model.Country);
			//	//model.LocalityCandidates = GetLocalityCandidates(model.Country);
			//	//model.DependentLocalityCandidates = GetDependentLocalityCandidates(model.Country);

			//	model.FormattedAddress = await addressDataService.FormatHtmlAsync(model.Address);
			//}

			// TODO: Validate both addresses!

			using (var service = new AddressDataService())
			{
				var factory = new AddressModelFactory();

				model.VisitAddress = await factory.CreateAsync(service, model.VisitAddress);
				model.VisitAddressHtmlFormatted = await service.FormatHtmlAsync(model.VisitAddress);
				model.VisitAddressStringFormatted = await service.FormatStringAsync(model.VisitAddress);
				
				model.PostalAddress = await factory.CreateAsync(service, model.PostalAddress);
				model.PostalAddressHtmlFormatted = await service.FormatHtmlAsync(model.PostalAddress);
				model.PostalAddressStringFormatted = await service.FormatStringAsync(model.PostalAddress);
			}

			return View(model);
		}
	}
}