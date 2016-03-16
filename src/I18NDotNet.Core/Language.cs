using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace I18N
{
	/// <summary>
	/// Representation of a BCP47 language tag
	/// See: https://tools.ietf.org/html/bcp47
	/// </summary>
	public struct Language
	{
		/// <summary>
		/// Regex to validate the well-formedness of a language tag
		/// Source: http://schneegans.de/lv/
		/// </summary>
		private static readonly Regex BCP47Regex = new Regex(@"^
(
  (
    (
      (
        (?'language'
          [a-z]{2,3}
        )
        (-
          (?'extlang'
            [a-z]{3}
          )
        ){0,3}
      )
      |
      (?'language'
        [a-z]{4}
      )
      |
      (?'language'
        [a-z]{5,8}
      )
    )

    (-(?'script'
      [a-z]{4}
    ))?

    (-(?'region'
      [a-z]{2}
      |
      [0-9]{3}
    ))?

    (-
      (?'variant'
        [a-z0-9]{5,8}
        |
        [0-9][a-z0-9]{3}
      )
    )*
    
    (-
      (?'extensions'
        [a-z0-9-[x]]
        (-
          [a-z0-9]{2,8}
        )+
      )
    )*
    
    (-
      x(- 
        (?'privateuse'
          [a-z0-9]{1,8}
        )
      )+
    )?
  )
  |
  (
    x(- 
      (?'privateuse'
        [a-z0-9]{1,8}
      )
    )+
  )
  |
  (?'grandfathered'
    (?'irregular'
      en-GB-oed |
      i-ami |
      i-bnn |
      i-default |
      i-enochian |
      i-hak |
      i-klingon |
      i-lux |
      i-mingo |
      i-navajo |
      i-pwn |
      i-tao |
      i-tay |
      i-tsu |
      sgn-BE-FR |
      sgn-BE-NL |
      sgn-CH-DE
    )
    |
    (?'regular'
      art-lojban |
      cel-gaulish |
      no-bok |
      no-nyn |
      zh-guoyu |
      zh-hakka |
      zh-min |
      zh-min-nan |
      zh-xiang
    )
  )
)
$");

		private static string[] NonLatinLanguages = {"ar", "hy", "zh", "ja", "ko", "ru", "th", "uk", "vi"};

		public Language(string code)
		{
			if (code == null)
				throw new ArgumentNullException(nameof(code));

			if (!BCP47Regex.IsMatch(code))
				throw new ArgumentException("Supplied code is not a valid BCP47 language tag");

			Code = code;

			if (NonLatinLanguages.Contains(code))
				Latin = false;
			

			// TODO
		}

		public string Code { get; }
		public bool Latin { get; }
	}


}