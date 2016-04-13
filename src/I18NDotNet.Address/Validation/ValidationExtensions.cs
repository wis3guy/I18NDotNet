using System;
using System.Threading.Tasks;

namespace I18N.Address.Validation
{
	public static class ValidationExtensions
	{
		public static async Task<IAddressValidationResult> ValidateAsync(this AddressDataService service, IAddress model)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (model == null) throw new ArgumentNullException(nameof(model));

			var validator = new AddressValidator(service);

			return await validator.ValidateAsync(model);
		}

		public static async Task EnsureValidAsync(this AddressDataService service, IAddress model)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (model == null) throw new ArgumentNullException(nameof(model));

			var result = await service.ValidateAsync(model);

			if (!result.IsValid)
				throw new AddressValidationException(model, result);
		}
	}
}
