using System;
using System.Threading.Tasks;

namespace I18N.Address.Validation
{
	public static class AdressValidationExtensions
	{
		public static async Task<IAddressValidationResult> ValidateAsync(this IAddressDataService service, AddressModel model)
		{
			if (!service.SupportsCountry(model.Country))
				throw new ArgumentException("Cannot validate address, because the country is not supported", nameof(model));

			var addressData = await service.GetAddressDataAsync(model.Country);

			// TODO: Get the most specific data you can. For now we just use the country.

			var validator = new AddressValidator(addressData);

			return validator.Validate(model);
		}
	}
}
