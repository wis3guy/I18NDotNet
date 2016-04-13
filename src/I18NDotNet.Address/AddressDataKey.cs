using System;
using System.Collections.Generic;

namespace I18N.Address
{
	public class AddressDataKey
	{
		private string _languageCode;
		private string _key;
		private readonly List<string> _parts;

		public AddressDataKey(string countryCode)
		{
			_parts = new List<string>(new[] {countryCode});
		}

		public void SetLanguage(string languageCode)
		{
			_languageCode = languageCode;
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

			if (_languageCode != null)
				key = $"{key}--{_languageCode}";

			return key;
		}
	}
}