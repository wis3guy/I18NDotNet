using System;

namespace I18N.Address
{
	public class Address : IAddress
	{
		private readonly IAddress _inner;
		
		public Address(IAddress inner)
		{
			if (inner == null) throw new ArgumentNullException(nameof(inner));

			_inner = inner;
		}

		public string[] this[AddressFieldKey key]
		{
			get
			{
				switch (key)
				{
					case AddressFieldKey.N:
						return new[] {Name};
					case AddressFieldKey.O:
						return new[] {Organisation};
					case AddressFieldKey.A:
						return AddressLine;
					case AddressFieldKey.D:
						return new[] {DependentLocality};
					case AddressFieldKey.C:
						return new[] {Locality};
					case AddressFieldKey.S:
						return new[] {AdministrativeArea};
					case AddressFieldKey.Z:
						return new[] {PostalCode};
					case AddressFieldKey.X:
						return new[] {SortingCode};
					case AddressFieldKey.Country:
						return new[] {CountryCode};
					case AddressFieldKey.Language:
						return new[] {LanguageCode};
					default:
						throw new ArgumentOutOfRangeException(nameof(key), key, null);
				}
			}
		}

		public string Name => _inner.Name;
		public string Organisation => _inner.Organisation;
		public string[] AddressLine => _inner.AddressLine;
		public string Locality => _inner.Locality;
		public string DependentLocality => _inner.DependentLocality;
		public string AdministrativeArea => _inner.AdministrativeArea;
		public string PostalCode => _inner.PostalCode;
		public string SortingCode => _inner.SortingCode;
		public string CountryCode => _inner.CountryCode;
		public string LanguageCode => _inner.LanguageCode;
	}
}