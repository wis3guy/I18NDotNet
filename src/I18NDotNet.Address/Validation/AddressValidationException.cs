using System;

namespace I18N.Address.Validation
{
	public class AddressValidationException : Exception
	{
		public AddressValidationException(AddressModel address, IAddressValidationResult result): base("The address is invalid, see result property for more details.")
		{
			Address = address;
			Result = result;
		}

		public AddressModel Address { get; }
		public IAddressValidationResult Result { get; }
	}
}