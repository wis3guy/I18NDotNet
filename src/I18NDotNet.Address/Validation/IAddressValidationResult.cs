using System.Collections.Generic;

namespace I18N.Address.Validation
{
	public interface IAddressValidationResult : IEnumerable<IAddressFieldValidationFailure>
	{
		bool IsValid { get; }
	}
}