using System;
using System.Text;

namespace I18N.Address.Formatting
{
	internal class AddressStringFormatter : IAddressFormatter
	{
		public string Format(AddressModel model, string country, string format)
		{
			if (model == null) throw new ArgumentNullException(nameof(model));
			if (country == null) throw new ArgumentNullException(nameof(country));
			if (format == null) throw new ArgumentNullException(nameof(format));

			var builder = new StringBuilder();
			var addressFieldIndex = 0;
			var flag = false;

			foreach (var c in format.ToCharArray())
			{
				if (c == '%')
				{
					flag = true;
				}
				else
				{
					if (flag)
					{
						if (c == 'n')
						{
							builder.Append("\n");
						}
						else
						{
							var field = (AddressFieldKey) Enum.Parse(typeof (AddressFieldKey), c.ToString());

							if (field == AddressFieldKey.A)
							{
								builder.Append(model.GetCleanValues(field)[addressFieldIndex]);
								addressFieldIndex++;
							}
							else
							{
								builder.Append(model.GetCleanValue(field));
							}
						}

						flag = false;
					}
					else
					{
						builder.Append(c);
					}
				}
			}

			builder.AppendFormat("\n{0}", country);

			return builder.ToString();
		}
	}
}