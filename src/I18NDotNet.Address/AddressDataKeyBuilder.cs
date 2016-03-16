using System;
using System.Collections.Generic;

namespace I18N.Address
{
	public class AddressDataKeyBuilder
	{
		private Language? _language;
		private string _key;
		private readonly List<string> _parts;

		public AddressDataKeyBuilder(Country country)
		{
			_parts = new List<string>(new[] {country.Code});
		}

		public void SetLanguage(Language language)
		{
			_language = language;
			_key = null;
		}

		public void Append(string part)
		{
			if (string.IsNullOrEmpty(part))
				throw new ArgumentNullException(nameof(part));

			_parts.Add(part);
			_key = null;
		}

		public override string ToString()
		{
			return _key ?? (_key = BuildKey());
		}

		private string BuildKey()
		{
			var key = string.Join("/", _parts);

			if (_language.HasValue)
				key = $"{key}--{_language.Value.Code}";

			return key;
		}
	}
}