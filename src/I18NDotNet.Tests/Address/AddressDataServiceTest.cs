using System.Globalization;
using I18N;
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
			var address = new AddressModel(culture)
			{
				Name = "Geoffrey Braaf",
				AddressLine = { "Brouwersveld 65"},
				PostalCode = "1541 PE",
				City = "Koog aan de Zaan"
			};

			using (var sut = new AddressDataService())
			{
				var result = await sut.ValidateAsync(address);

				Assert.NotNull(result);
			}
		}
    }
}
