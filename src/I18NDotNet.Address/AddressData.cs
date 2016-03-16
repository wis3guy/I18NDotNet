using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace I18N.Address
{
	public class AddressData
	{
		private const char ListItemDelimiter = '~';
		private const string Keys = "sub_keys";
		private const string LocalNames = "sub_lnames";
		private const string LatinNames = "sub_names";

		private readonly IDictionary<string, string> _data;

		public AddressData(IDictionary<string, string> data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

			_data = data;
		}

		public Regex ZipRegex
		{
			get
			{
				if (_data.ContainsKey("zip"))
					return new Regex(_data["zip"]);

				return null;
			}
		}

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

			if (!_data.ContainsKey(Keys))
				return null;

			var candidates = _data[Keys].Split(ListItemDelimiter);
			var match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

			if (match != null)
				return match;

			if (_data.ContainsKey(LocalNames))
			{
				candidates = _data[LocalNames].Split(ListItemDelimiter);
				match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

				if (match != null)
					return match;
			}

			if (!_data.ContainsKey(LatinNames))
				return null;

			candidates = _data[LatinNames].Split(ListItemDelimiter);
			match = candidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);

			return match;
		}

		public bool IsRequiredField(AddressFieldKey key)
		{
			return _data.ContainsKey("require") && _data["require"].Contains($"{key}");
		}

		public bool IsExpectedField(AddressFieldKey key)
		{
			return _data.ContainsKey("fmt") && _data["fmt"].Contains($"%{key}");
		}
	}
}
