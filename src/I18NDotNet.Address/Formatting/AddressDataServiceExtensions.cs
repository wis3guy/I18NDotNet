using System;
using System.Threading.Tasks;
using I18N.Address.Validation;

namespace I18N.Address.Formatting
{
	public static class AddressDataServiceExtensions
	{
		public static Task<string> FormatStringAsync(this AddressDataService service, IAddress model)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (model == null) throw new ArgumentNullException(nameof(model));

			return service.FormatAsync(new AddressStringFormatter(), model);
		}

		public static Task<string> FormatHtmlAsync(this AddressDataService service, IAddress model)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (model == null) throw new ArgumentNullException(nameof(model));

			return service.FormatAsync(new AddressHtmlFormatter(), model);
		}

		public static async Task<string> FormatAsync(this AddressDataService service, IAddressFormatter formatter, IAddress model)
		{
			if (service == null) throw new ArgumentNullException(nameof(service));
			if (formatter == null) throw new ArgumentNullException(nameof(formatter));
			if (model == null) throw new ArgumentNullException(nameof(model));

			await service.EnsureValidAsync(model);

			var wrapper = new AddressFormatterWrapper(service);
			
			return await wrapper.FormatAsync(model, formatter);
		}
	}
}
