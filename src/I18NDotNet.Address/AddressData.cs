using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace I18N.Address
{
	public class AddressData : IReadOnlyDictionary<string, string>
	{
		private readonly List<KeyValuePair<string, IDictionary<string, string>>> _data;
		
		public AddressData()
		{
			_data = new List<KeyValuePair<string, IDictionary<string, string>>>
			{
				new KeyValuePair<string, IDictionary<string, string>>(
					RegionDataConstants.DefaultCountryCode,
					RegionDataConstants.Get(RegionDataConstants.DefaultCountryCode))
			};
		}

		private IDictionary<string, string> MostSpecific => _data.Last().Value;

		public void Refine(string key, IDictionary<string, string> data)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));
			if (data == null) throw new ArgumentNullException(nameof(data));

			var merged = new Dictionary<string, string>();

			foreach (var pair in MostSpecific)
			{
				var property = pair.Key;
				var value = pair.Value;

				if (data.ContainsKey(property) && !string.IsNullOrEmpty(data[property]))
					value = data[property];

				merged.Add(property, value);
			}

			foreach (var property in data.Keys.Except(merged.Keys))
			{
				var value = data[property];

				if (!string.IsNullOrEmpty(value))
					merged.Add(property, value);
			}

			_data.Add(new KeyValuePair<string, IDictionary<string, string>>(key, merged));
		}

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			return MostSpecific.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int Count => MostSpecific.Count;

		public bool ContainsKey(string key)
		{
			return MostSpecific.ContainsKey(key);
		}

		public bool TryGetValue(string key, out string value)
		{
			return MostSpecific.TryGetValue(key, out value);
		}

		public string this[string key] => MostSpecific[key];
		public IEnumerable<string> Keys => MostSpecific.Keys;
		public IEnumerable<string> Values => MostSpecific.Values;

		public static class Properties
		{
			public const string Name = "name";
			public const string SubRegionKeys = "sub_keys";
			public const string SubRegionNames = "sub_names";
			public const string SubRegionLatinNames = "sub_lnames";
			public const string RequiredFields = "require";
			public const string CurrentLanguage = "lang";
			public const string SupportedLanguages = "languages";
			public const string Format = "fmt";
			public const string ZipRegex = "zip";
		}
	}
}