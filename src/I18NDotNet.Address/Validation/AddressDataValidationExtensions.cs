using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace I18N.Address.Validation
{
	public static class AddressDataValidationExtensions
	{
		public static bool IsRequiredField(this AddressData data, AddressFieldKey field)
		{
			return data.ContainsKey(AddressData.Properties.RequiredFields) && data[AddressData.Properties.RequiredFields].Contains($"{field}");
		}

		public static bool IsExpectedField(this AddressData data, AddressFieldKey field)
		{
			return data.ContainsKey(AddressData.Properties.Format) && data[AddressData.Properties.Format].Contains($"{field}");
		}

		public static bool IsValidPostalCodeField(this AddressData data, string input)
		{
			return !data.ContainsKey(AddressData.Properties.ZipRegex) || Regex.IsMatch(input, data[AddressData.Properties.ZipRegex]);
		}
	}
}
