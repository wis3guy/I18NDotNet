using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace I18N.Address
{
	public class AddressData
	{
		public class PropertyNames
		{
			public const string SubRegionKeysPropertyName = "sub_keys";
			public const string SubRegionLocalNamesPropertyName = "sub_lnames";
			public const string SubRegionLatinNamesPropertyName = "sub_names";
			public const string RequiredFieldsPropertyName = "require";
			public const string CurrentLanguagePropertyName = "language";
			public const string SupportedLanguagesPropertyName = "languages";
			public const string FormatPropertyName = "fmt";
		}

		private const char ListItemDelimiter = '~';


		private readonly IDictionary<string, string> _data;

		public AddressData(IDictionary<string, string> data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

			_data = data;
		}

		public Regex ZipRegex => _data.ContainsKey("zip") ? new Regex(_data["zip"]) : null;

		/// <summary>
		/// Creates a new instance with all of the current values, overwritten by (non-null) values from the more specific instance.
		/// </summary>
		/// <param name="moreSpecific">Addres data to overwrite known values with</param>
		/// <returns>A refined instance of the address data</returns>
		public AddressData Refine(AddressData moreSpecific)
		{
			var data = new Dictionary<string, string>(_data);

			foreach (var key in moreSpecific._data.Keys)
			{
				var value = moreSpecific._data[key];

				if (string.IsNullOrEmpty(value))
					continue; // no value to override with ...

				if (data.ContainsKey(key))
					data[key] = value;
				else
					data.Add(key, value);
			}

			return new AddressData(data);
		}

		/// <summary>
		/// Gets the data key part of the subregion, for the given input.
		/// </summary>
		/// <param name="input">Case-insensitive key, latin name or local name</param>
		/// <returns>Key if value is known, otherwise null</returns>
		public string GetSubRegionKeyForInputValue(string input)
		{
			var lowercase = input.ToLowerInvariant();

			if (!_data.ContainsKey(PropertyNames.SubRegionKeysPropertyName))
				return null;

			var candidates = _data[PropertyNames.SubRegionKeysPropertyName].Split(ListItemDelimiter);
			var match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

			if (match != null)
				return match;

			if (_data.ContainsKey(PropertyNames.SubRegionLocalNamesPropertyName))
			{
				candidates = _data[PropertyNames.SubRegionLocalNamesPropertyName].Split(ListItemDelimiter);
				match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

				if (match != null)
					return match;
			}

			if (!_data.ContainsKey(PropertyNames.SubRegionLatinNamesPropertyName))
				return null;

			candidates = _data[PropertyNames.SubRegionLatinNamesPropertyName].Split(ListItemDelimiter);
			match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

			return match;
		}

		public bool IsRequiredField(AddressFieldKey key)
		{
			return _data.ContainsKey(PropertyNames.RequiredFieldsPropertyName) && _data[PropertyNames.RequiredFieldsPropertyName].Contains($"{key}");
		}

		public bool IsExpectedField(AddressFieldKey key)
		{
			return _data.ContainsKey(PropertyNames.FormatPropertyName) && _data[PropertyNames.FormatPropertyName].Contains($"%{key}");
		}

		public bool IsSupportedLanguage(Language language)
		{
			if (_data.ContainsKey(PropertyNames.CurrentLanguagePropertyName))
			{
				var current = _data[PropertyNames.CurrentLanguagePropertyName];

				if (current != null)
					return current == language.Code;
			}

			if (!_data.ContainsKey(PropertyNames.SupportedLanguagesPropertyName))
				return false;

			var supported = _data[PropertyNames.SupportedLanguagesPropertyName].Split(ListItemDelimiter);

			return supported.Any(x => x == language.Code);
		}
	}
}
