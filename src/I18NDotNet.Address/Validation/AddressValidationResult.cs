using System.Collections.Generic;

namespace I18N.Address.Validation
{
	internal class AddressValidationResult : List<IAddressFieldValidationFailure>, IAddressValidationResult
	{
		public bool IsValid => Count == 0;
	}
}