using System;
using System.Collections.Generic;
using System.Linq;

namespace I18N.Address.Validation
{
	internal static class AddressInputExtensions
	{
		public static string GetCleanCountryCodeValue(this AddressModel address)
		{
			return GetCleanValue(address.Country.Code);
		}

		public static string[] GetCleanValue(this AddressModel address, AddressFieldKey key)
		{
			return GetCleanValue(GetValue(address, key)).ToArray();
		}

		private static IEnumerable<string> GetCleanValue(IEnumerable<string> result)
		{
			return result.Select(GetCleanValue);
		}

		private static string GetCleanValue(string value)
		{
			if (value == null)
			{
				return null;
			}
			else
			{
				var cleaned = value.Trim();

				if (string.IsNullOrEmpty(cleaned))
					return null;

				return cleaned;
			}
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
				default:
					throw new ArgumentOutOfRangeException(nameof(key), key, null);
			}
		}
	}
}