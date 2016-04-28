using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace I18N.Address
{
	public class AddressData : IReadOnlyDictionary<string, string>
	{
		public const char ListItemDelimiter = '~';

		private readonly IDictionary<AddressDataContext, IReadOnlyDictionary<string, string>> _historical;

		private IReadOnlyDictionary<string, string> _mostSpecific;

		public AddressData()
		{
			var key = new AddressDataKey(RegionDataConstants.DefaultCountryCode);
			var data = RegionDataConstants.Get(key);

			data.Add("_key", key.ToString());

			var wrapped = new ReadOnlyDictionary<string, string>(data);

			_historical = new Dictionary<AddressDataContext, IReadOnlyDictionary<string, string>>
			{
				{AddressDataContext.Default, wrapped}
			};

			_mostSpecific = wrapped;
		}

		public void Refine(AddressDataKey key, IDictionary<string, string> data)
		{
			if (key == null) throw new ArgumentNullException(nameof(key));
			if (data == null) throw new ArgumentNullException(nameof(data));

			var merged = new Dictionary<string, string>();

			foreach (var pair in _mostSpecific)
			{
				var property = pair.Key;

				if ((property == Properties.SubRegionKeys) ||
					(property == Properties.SubRegionNames) ||
					(property == Properties.SubRegionLatinNames))
					continue; // these values are not maintained across levels ...

				var value = pair.Value;

				merged.Add(property, value);
			}

			foreach (var property in data.Keys)
			{
				var value = data[property];

				if (merged.ContainsKey(property))
					merged[property] = value;
				else
					merged.Add(property, value);
			}

			merged["_key"] = key.ToString();

			var wrapped = new ReadOnlyDictionary<string, string>(merged);

			if (_historical.ContainsKey(key.Context))
				_historical[key.Context] = wrapped;
			else
				_historical.Add(key.Context, wrapped);

			_mostSpecific = _historical[_historical.Keys.Max()];
		}

		public IReadOnlyDictionary<string, string> this[AddressDataContext key] => _historical[key];

		public bool ContainsKey(AddressDataContext key)
		{
			return _historical.ContainsKey(key);
		}

		public bool ContainsKey(string key)
		{
			return _mostSpecific.ContainsKey(key);
		}

		public bool TryGetValue(string key, out string value)
		{
			return _mostSpecific.TryGetValue(key, out value);
		}

		public string this[string property] => _mostSpecific[property];
		public IEnumerable<string> Keys => _mostSpecific.Keys;
		public IEnumerable<string> Values => _mostSpecific.Values;

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			return _mostSpecific.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int Count => _mostSpecific.Count;

		public static class Properties
		{
			public const string AdministrativeAreaNameType = "state_name_type";
			public const string LocalityNameType = "locality_name_type";
			public const string DependentLocalityNameType = "sublocality_name_type";
			public const string ZipNameType = "zip_name_type";
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