using System.Collections.Generic;
using System.Linq;

namespace I18N.Address.Validation
{
	internal class AddressValidationResult : List<IAddressFieldValidationResult>, IAddressValidationResult
	{
		public AddressValidationResult(IEnumerable<AddressFieldValidationResult> collection):base(collection)
		{
		}

		public bool IsValid => this.All(x => x.IsValid);
	}
}