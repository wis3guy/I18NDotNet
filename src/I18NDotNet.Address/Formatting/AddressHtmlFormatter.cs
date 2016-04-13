using System;
using System.Text;

namespace I18N.Address.Formatting
{
	internal class AddressHtmlFormatter : IAddressFormatter
	{
		public string Format(IAddress address, string country, string format)
		{
			if (address == null) throw new ArgumentNullException(nameof(address));
			if (country == null) throw new ArgumentNullException(nameof(country));
			if (format == null) throw new ArgumentNullException(nameof(format));

			var builder = new StringBuilder();
			var addressFieldIndex = 0;
			var flag = false;
			var model = new Address(address);

			builder.Append("<div class=\"address\">");
			builder.Append("<div class=\"line\">");

			foreach (var c in format.ToCharArray())
			{
				if (c == '%')
				{
					flag = true;
					continue;
				}

				if (!flag)
				{
					builder.Append(c);
					continue;
				}

				flag = false;

				if (c == 'n')
				{
					builder.Append("</div><div class=\"line\">");
					continue;
				}

				string value;
				string css;
				var field = (AddressFieldKey) Enum.Parse(typeof (AddressFieldKey), c.ToString());

				if (field == AddressFieldKey.A)
				{
					value = model.GetCleanValues(field)[addressFieldIndex];
					css = $"address address_{addressFieldIndex + 1}";
					addressFieldIndex++;
				}
				else
				{
					value = model.GetCleanValue(field);
					css = $"{c} ";

					switch (field)
					{
						case AddressFieldKey.N:
							css += "name";
							break;
						case AddressFieldKey.O:
							css += "organisation";
							break;
						case AddressFieldKey.D:
							css += "dependent-locality";
							break;
						case AddressFieldKey.C:
							css += "city";
							break;
						case AddressFieldKey.S:
							css += "administrative-area";
							break;
						case AddressFieldKey.Z:
							css += "postal-code";
							break;
						case AddressFieldKey.X:
							css += "sorting-code";
							break;
					}
				}

				builder.AppendFormat("\n<span class=\"{0}\">{1}</span>", css, value);
			}

			builder.Append("</div>"); // line
			builder.AppendFormat("<div class=\"line\"><span class=\"country\">{0}</span></div>", country);
			builder.Append("</div>"); // address

			return builder.ToString();
		}
	}
}