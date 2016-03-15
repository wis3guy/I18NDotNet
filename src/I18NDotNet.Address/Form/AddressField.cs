using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace I18N.Address.Form
{
	public class AddressField : Dictionary<string, string>, IAddressField
	{
		public AddressFieldKey Key { get; set; }
		public string Value { get; set; }
		public Regex ValidationRule { get; set; }
		public IReadOnlyDictionary<string, string> PossibleValues => new ReadOnlyDictionary<string, string>(this);

		public bool IsReadOnly => Value != null;
		public bool IsSelect => Count > 0;
		public bool HasRule => ValidationRule != null;
	}
}