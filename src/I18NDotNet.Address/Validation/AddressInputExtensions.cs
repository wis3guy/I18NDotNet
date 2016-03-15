using System;
using System.Collections.Generic;
using System.Linq;

namespace I18N.Address.Validation
{
	internal static class AddressInputExtensions
	{
		public static string[] GetCleanValue(this AddressModel address, AddressFieldKey key)
		{
			return GetCleanValue(GetValue(address, key)).ToArray();
		}

		private static IEnumerable<string> GetCleanValue(IEnumerable<string> result)
		{
			foreach (var value in result)
			{
				if (value == null)
				{
					yield return null;
				}
				else
				{
					var cleaned = value.Trim();

					if (string.IsNullOrEmpty(cleaned))
						yield return null;

					yield return cleaned;
				}
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