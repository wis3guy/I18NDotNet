using System;
using System.Linq;

namespace I18N.Address
{
	internal static class AddressInpuSanitizingExtensions
	{
		public static string GetCleanValue(this KeyedAddress address, AddressFieldKey key)
		{
			if (key == AddressFieldKey.A)
				throw new InvalidOperationException("An address can have multiple address lines");

			return GetCleanValues(address, key).Single();
		}

		public static string[] GetCleanValues(this KeyedAddress address, AddressFieldKey key)
		{
			return address[key].Select(GetCleanValue).ToArray();
		}

		private static string GetCleanValue(string value)
		{
			var cleaned = value?.Trim();

			return string.IsNullOrEmpty(cleaned) ? null : cleaned;
		}
	}
}