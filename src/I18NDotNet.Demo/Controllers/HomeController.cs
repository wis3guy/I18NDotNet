using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using I18N.Address;
using I18N.Address.Formatting;
using I18N.Address.Validation;

namespace I18NDotNet.Demo.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public async Task<ActionResult> Index()
		{
			using (var addressDataService = new AddressDataService())
			{
				var culture = CultureInfo.CurrentUICulture;
				var region = new RegionInfo(culture.LCID);

				var model = new FormModel
				{
					VisitAddress = new AddressModel
					{
						LanguageCode = culture.TwoLetterISOLanguageName,
						CountryCandidates = GetCountryCandidates(addressDataService),
						CountryCode = addressDataService.SupportsCountry(region.TwoLetterISORegionName)
							? region.TwoLetterISORegionName
							: $"ZZ_{region.TwoLetterISORegionName}",
					},
					PostalAddress = new AddressModel
					{
						LanguageCode = culture.TwoLetterISOLanguageName,
						CountryCandidates = GetCountryCandidates(addressDataService),
						CountryCode = addressDataService.SupportsCountry(region.TwoLetterISORegionName)
							? region.TwoLetterISORegionName
							: $"ZZ_{region.TwoLetterISORegionName}",
					}
				};

				var key = new AddressDataKey(region.TwoLetterISORegionName);
				var data = await addressDataService.GetAddressDataAsync(key);

				// TODO: model.AdministrativeAreaCandidates = data.

				return View(model);
			}
		}

		[HttpPost]
		public async Task<ActionResult> Index(AddressModel model)
		{
			using (var addressDataService = new AddressDataService())
			{
				var result = await addressDataService.ValidateAsync(model.Address);

				if (!result.IsValid)
				{
					foreach (var failure in result)
					{
						var key = "???"; // TODO: How to get this key from the enum value?
						string message;

						switch (failure.Reason)
						{
							case ValidationFailureReason.Required:
								message = $"{key} is required";
								break;
							case ValidationFailureReason.Invalid:
								message = $"{key} has an invalid value";
								break;
							case ValidationFailureReason.Unexpected:
								message = $"{key} has an unexpected value";
								break;
							case ValidationFailureReason.Uknown:
								message = "Unknown data key";
								break;
							default:
								throw new ArgumentOutOfRangeException();
						}

						ModelState.AddModelError(key, message);
					}
				}

				//model.CountryCandidates = GetCountryCandidates();
				//model.LanguageCandidates = GetLanguageCandidates(model.Country);
				//model.AdministrativeAreaCandidates = GetAdministrativeAreaCandidates(model.Country);
				//model.LocalityCandidates = GetLocalityCandidates(model.Country);
				//model.DependentLocalityCandidates = GetDependentLocalityCandidates(model.Country);

				model.FormattedAddress = await addressDataService.FormatHtmlAsync(model.Address);
			}

			return View(model);
		}

		/*
		
			public IAddress(Country country, Language language)
		{
			Language = language;
			Country = country;
			AddressLine = new List<string>();
		}

		public IAddress(CultureInfo culture)
		{
			if (culture == null)
				throw new ArgumentNullException(nameof(culture));

			Language = new Language(culture.TwoLetterISOLanguageName);

			var region = new RegionInfo(culture.Name);

			Country = new Country(region.TwoLetterISORegionName);
			AddressLine = new List<string>();
		}*/
		private IEnumerable<SelectListItem> GetDependentLocalityCandidates(string country)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<SelectListItem> GetLocalityCandidates(string country)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<SelectListItem> GetAdministrativeAreaCandidates(string country)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<SelectListItem> GetLanguageCandidates(string country)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<SelectListItem> GetCountryCandidates(AddressDataService addressDataService)
		{
			var countries = new HashSet<string>();
			var items = new List<SelectListItem>();

			foreach (var culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
			{
				var region = new RegionInfo(culture.LCID);

				if (countries.Contains(region.TwoLetterISORegionName))
					continue;

				if (addressDataService.SupportsCountry(region.TwoLetterISORegionName))
				{
					items.Add(new SelectListItem
					{
						Value = region.TwoLetterISORegionName,
						Text = region.EnglishName
					});
				}
				else
				{
					items.Add(new SelectListItem
					{
						Value = $"ZZ_{region.TwoLetterISORegionName}",
						Text = region.DisplayName
					});
				}

				countries.Add(region.TwoLetterISORegionName);
			}

			return items.OrderBy(x => x.Text);
		}
	}

	public class AddressModel : IAddress
	{
		public IEnumerable<SelectListItem> CountryCandidates { get; set; }
		public IEnumerable<SelectListItem> AdministrativeAreaCandidates { get; set; }
		public IEnumerable<SelectListItem> LocalityCandidates { get; set; }
		public IEnumerable<SelectListItem> DependentLocalityCandidates { get; set; }

		public IEnumerable<AddressFieldSpec> Fields { get; set; }

		public IAddress Address { get; set; }
		public string FormattedAddress { get; set; }

		public string Name { get; set; }
		public string Organisation { get; set; }
		public string[] AddressLine { get; set; }
		public string City { get; set; }
		public string DependentLocality { get; set; }
		public string AdministrativeArea { get; set; }
		public string PostalCode { get; set; }
		public string SortingCode { get; set; }
		public string CountryCode { get; set; }
		public string LanguageCode { get; set; }
	}

	public class FormModel
	{
		public AddressModel VisitAddress { get; set; }
		public AddressModel PostalAddress { get; set; }
	}

	public class AddressFieldSpec
	{
		public AddressFieldKey Field { get; set; }
		public bool Required { get; set; }
	}
}