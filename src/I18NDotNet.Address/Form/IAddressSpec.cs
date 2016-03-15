using System.Collections.Generic;
using System.Globalization;

namespace I18N.Address.Form
{
	public interface IAddressSpec
	{
		RegionInfo Region { get; }
		IEnumerable<IAddressField> Fields { get; }
	}
}