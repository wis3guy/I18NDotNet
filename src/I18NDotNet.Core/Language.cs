using System;
using System.Text.RegularExpressions;

namespace I18N
{
	/// <summary>
	/// Representation of a language
	/// </summary>
	public struct Language
	{
		/// <summary>
		/// Regex to validate the well-formedness of a language tag
		/// Source: http://schneegans.de/lv/
		/// </summary>
		private static readonly Regex BCP47Regex = new Regex(@"^(((((?'language'[a-z]{2,3})(-(?'extlang'[a-z]{3})){0,3})|(?'language'[a-z]{4})|(?'language'[a-z]{5,8}))(-(?'script'[a-z]{4}))?(-(?'region'[a-z]{2}|[0-9]{3}))?(-(?'variant'[a-z0-9]{5,8}|[0-9][a-z0-9]{3}))*(-(?'extensions'[a-z0-9-[x]](-[a-z0-9]{2,8})+))*(-x(-(?'privateuse'[a-z0-9]{1,8}))+)?)|(x(-(?'privateuse'[a-z0-9]{1,8}))+)|(?'grandfathered'(?'irregular'en-GB-oedi-amii-bnni-defaulti-enochiani-haki-klingoni-luxi-mingoi-navajoi-pwni-taoi-tayi-tsusgn-BE-FRsgn-BE-NLsgn-CH-DE)|(?'regular'art-lojbancel-gaulishno-bokno-nynzh-guoyuzh-hakkazh-minzh-min-nanzh-xiang)))$");

		public Language(string code)
		{
			if (code == null)
				throw new ArgumentNullException(nameof(code));

			var match = BCP47Regex.Match(code);

			if (!match.Success)
				throw new ArgumentException("Supplied language code is not a well-formed BCP47 (https://tools.ietf.org/html/bcp47) language tag");

			Code = match.Groups["language"].Value;

			IsForcedLatin = match.Groups["script"].Success && match.Groups["script"].Value == "Latn";
		}

		public string Code { get; }
		public bool IsForcedLatin { get; }
	}
}