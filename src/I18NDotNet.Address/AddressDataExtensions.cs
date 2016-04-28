using System;
using System.Collections.Generic;
using System.Linq;

namespace I18N.Address
{
	public static class AddressDataExtensions
	{
		public static bool ContainsLanguage(this AddressData data, string languageCode)
		{
			if (data.ContainsKey(AddressData.Properties.CurrentLanguage))
			{
				var current = data[AddressData.Properties.CurrentLanguage];

				if (current != null)
					return current == languageCode;
			}

			if (!data.ContainsKey(AddressData.Properties.SupportedLanguages))
				return false;

			var supported = data[AddressData.Properties.SupportedLanguages].Split(AddressData.ListItemDelimiter);

			return supported.Any(x => x == languageCode);
		}

		public static string GetSubRegionKeyForInputValue(this AddressData data, string languageCode, string input, AddressDataContext context)
		{
			if (data == null) throw new ArgumentNullException(nameof(data));
			if (languageCode == null) throw new ArgumentNullException(nameof(languageCode));

			if (input == null)
				return null;

			var lowercase = input.ToLowerInvariant();
			var language = new Language(languageCode);

			if (!data[context].ContainsKey(AddressData.Properties.SubRegionKeys))
				return null;

			var keyCandidates = data[context][AddressData.Properties.SubRegionKeys].Split(AddressData.ListItemDelimiter);
			var match = keyCandidates.SingleOrDefault(x => x.ToLowerInvariant() == lowercase);
			
			if (match != null)
				return match;

			if (language.Code != data[AddressData.Properties.CurrentLanguage])
				return null; // data is in a completely different langauge, only keys could have matched ...

			return language.IsForcedLatin
				? GetSubRegionKeyForInputValue(data, keyCandidates, AddressData.Properties.SubRegionLatinNames, lowercase, context)
				: GetSubRegionKeyForInputValue(data, keyCandidates, AddressData.Properties.SubRegionNames, lowercase, context);
		}
		
		private static string GetSubRegionKeyForInputValue(AddressData data, IReadOnlyList<string> keyCandidates, string property, string input, AddressDataContext context)
		{
			if (!data.ContainsKey(property))
				return null;

			var textCandidates = data[context][property].Split(AddressData.ListItemDelimiter);

			for (var i = 0; i < textCandidates.Length; i++)
			{
				if (textCandidates[i].ToLowerInvariant() == input)
					return keyCandidates[i];
			}

			return null;
		}
	}
}