using System;

namespace I18N
{
    public struct Country
    {
	    public Country(string code)
	    {
		    if (code == null)
				throw new ArgumentNullException(nameof(code));

			if (code.Length != 2)
				throw new ArgumentException("Only 2 letter ISO country codes are supported", nameof(code));

			Code = code.ToUpperInvariant();
	    }

	    public string Code { get; }
    }
}
