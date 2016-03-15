using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace I18N.Address.Form
{
	public interface IAddressField
	{
		AddressFieldKey Key { get; set; }
		string Value { get; set; }
		Regex ValidationRule { get; set; }
		IReadOnlyDictionary<string, string> PossibleValues { get; }

		bool IsReadOnly { get; }
		bool IsSelect { get; }
		bool HasRule { get; }
	}
}