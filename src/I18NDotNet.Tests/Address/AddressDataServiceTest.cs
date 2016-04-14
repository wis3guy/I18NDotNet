using System.Globalization;
using I18N.Address;
using I18N.Address.Validation;
using Xunit;

namespace I18NDotNet.Tests.Address
{
    public class AddressDataServiceTest
    {
		[Fact]
	    public async void Foo()
		{
			var culture = new CultureInfo("nl-NL");
			var region = new RegionInfo(culture.LCID);
			var address = new Address
			{
				Name = "Geoffrey Braaf",
				AddressLine = new []{ "Brouwersveld 65"},
				PostalCode = "1541 PE",
				Locality = "Koog aan de Zaan",
				CountryCode = region.TwoLetterISORegionName,
				LanguageCode = culture.TwoLetterISOLanguageName
			};

			using (var sut = new AddressDataService())
			{
				var result = await sut.ValidateAsync(address);

				Assert.NotNull(result);
			}
		}
    }

	internal class Address : IAddress
	{
		public string Name {get; set;}
		public string Organisation {get; set;}
		public string[] AddressLine {get; set;}
		public string Locality {get; set;}
		public string DependentLocality {get; set;}
		public string AdministrativeArea {get; set;}
		public string PostalCode {get; set;}
		public string SortingCode {get; set;}
		public string CountryCode {get; set;}
		public string LanguageCode {get; set;}
	}
}
