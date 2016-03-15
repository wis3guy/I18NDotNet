using System;
using System.Collections.Generic;
using System.Globalization;

namespace I18N.Address.Form
{
	internal class AddressSpec : List<AddressField>, IAddressSpec
	{
		public AddressSpec(AddressDataResponse response)
		{
			throw new NotImplementedException();
		}

		public RegionInfo Region { get; set; }
		public IEnumerable<IAddressField> Fields => this;
	}
}