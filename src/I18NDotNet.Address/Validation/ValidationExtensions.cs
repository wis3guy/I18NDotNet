using System.Threading.Tasks;

namespace I18N.Address.Validation
{
	public static class ValidationExtensions
	{
		public static async Task<IAddressValidationResult> ValidateAsync(this IAddressDataService service, AddressModel model)
		{
			var validator = new AddressValidator(service);

			return await validator.ValidateAsync(model);
		}
	}
}
