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
			public const string SubRegionKeys = "sub_keys";
			public const string SubRegionNames = "sub_names";
			public const string SubRegionLatinNames = "sub_lnames";
			public const string RequiredFields = "require";
			public const string CurrentLanguage = "lang";
			public const string SupportedLanguages = "languages";
			public const string Format = "fmt";
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
		/// <param name="language">Language for which to perform the matching</param>
		/// <param name="input">Case-insensitive key, latin- or local-name</param>
		/// <returns>Key if value is known, otherwise null</returns>
		public string GetSubRegionKeyForInputValue(Language language, string input)
		{
			var lowercase = input.ToLowerInvariant();

			if (!_data.ContainsKey(PropertyNames.SubRegionKeys))
				return null;

			var candidates = _data[PropertyNames.SubRegionKeys].Split(ListItemDelimiter);
			var match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

			if (match != null)
				return match;

			if (language.Code != _data[PropertyNames.CurrentLanguage])
				return null; // data is in a completely different langauge, only keys could have matched ...

			if (language.IsForcedLatin)
			{
				if (!_data.ContainsKey(PropertyNames.SubRegionLatinNames))
					return null;

				candidates = _data[PropertyNames.SubRegionLatinNames].Split(ListItemDelimiter);
				match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

				return match;
			}

			if (!_data.ContainsKey(PropertyNames.SubRegionNames))
				return null;

			candidates = _data[PropertyNames.SubRegionNames].Split(ListItemDelimiter);
			match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

			return match;
		}

		public bool IsRequiredField(AddressFieldKey key)
		{
			return _data.ContainsKey(PropertyNames.RequiredFields) && _data[PropertyNames.RequiredFields].Contains($"{key}");
		}

		public bool IsExpectedField(AddressFieldKey key)
		{
			return _data.ContainsKey(PropertyNames.Format) && _data[PropertyNames.Format].Contains($"%{key}");
		}

		public bool IsSupportedLanguage(Language language)
		{
			if (_data.ContainsKey(PropertyNames.CurrentLanguage))
			{
				var current = _data[PropertyNames.CurrentLanguage];

				if (current != null)
					return current == language.Code;
			}

			if (_data.ContainsKey(PropertyNames.SupportedLanguages))
			{
				var supported = _data[PropertyNames.SupportedLanguages].Split(ListItemDelimiter);

				return supported.Any(x => x == language.Code);
			}

			return true; // no language info in the data, so assume it is supported ...
		}
	}
}
