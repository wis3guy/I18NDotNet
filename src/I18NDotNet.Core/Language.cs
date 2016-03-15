using System;

namespace I18N
{
	public struct Language
	{
		public Language(string code)
		{
			if (code == null)
				throw new ArgumentNullException(nameof(code));

			if (code.Length != 2)
				throw new ArgumentException("Only 2 letter ISO language codes are supported", nameof(code));

			Code = code.ToLowerInvariant();
		}

		public string Code { get; }
	}
}