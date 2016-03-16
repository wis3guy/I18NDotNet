using System;
using System.Collections.Generic;
using System.Linq;

namespace I18N.Address.Validation
{
	internal static class AddressModelExtensions
	{
		public static string GetCleanCountryCodeValue(this AddressModel address)
		{
			return GetCleanValues(address.Country.Code);
		}

		public static string GetCleanValue(this AddressModel address, AddressFieldKey key)
		{
			if (key == AddressFieldKey.A)
				throw new InvalidOperationException("An address can have multiple address lines");

			return GetCleanValues(address, key).Single();
		}

		public static string[] GetCleanValues(this AddressModel address, AddressFieldKey key)
		{
			return GetCleanValues(GetValue(address, key)).ToArray();
		}

		private static IEnumerable<string> GetCleanValues(IEnumerable<string> result)
		{
			return result.Select(GetCleanValues);
		}

		private static string GetCleanValues(string value)
		{
			var cleaned = value?.Trim();

			return string.IsNullOrEmpty(cleaned) ? null : cleaned;
		}

		private static IEnumerable<string> GetValue(AddressModel address, AddressFieldKey key)
		{
			switch (key)
			{
				case AddressFieldKey.N:
					return  new[] {address.Name};
				case AddressFieldKey.O:
					return  new[] {address.Organisation};
				case AddressFieldKey.A:
					return  address.AddressLine.Select(x => x);
				case AddressFieldKey.D:
					return  new[] {address.DependentLocality};
				case AddressFieldKey.C:
					return  new[] {address.City};
				case AddressFieldKey.S:
					return  new[] {address.AdministrativeArea};
				case AddressFieldKey.Z:
					return  new[] {address.PostalCode};
				case AddressFieldKey.X:
					return  new[] {address.SortingCode};
				case AddressFieldKey.Country:
					return new[] { address.Country.Code };
				case AddressFieldKey.Language:
					return new[] { address.Language.Code };
				default:
					throw new ArgumentOutOfRangeException(nameof(key), key, null);
			}
		}
	}
}