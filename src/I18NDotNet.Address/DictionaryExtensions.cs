using System.Collections.Generic;

namespace I18N.Address
{
	internal static class DictionaryExtensions
	{
		public static Dictionary<string, string> Override(this Dictionary<string, string> leastSpecific, Dictionary<string, string> moreSpecific)
		{
			var result = new Dictionary<string, string>(leastSpecific);

			foreach (var key in moreSpecific.Keys)
			{
				var value = moreSpecific[key];

				if (string.IsNullOrEmpty(value))
					continue; // no value to override with ...

				if (result.ContainsKey(key))
					result[key] = value;
				else
					result.Add(key, value);
			}

			return result;
		}
	}
}