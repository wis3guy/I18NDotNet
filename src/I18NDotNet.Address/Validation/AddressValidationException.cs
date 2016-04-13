using System;

namespace I18N.Address.Validation
{
	public class AddressValidationException : Exception
	{
		public AddressValidationException(IAddress address, IAddressValidationResult result): base("The address is invalid, see result property for more details.")
		{
			Address = address;
			Result = result;
		}

		public IAddress Address { get; }
		public IAddressValidationResult Result { get; }
	}
}