using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public static class HtmlHelperExtensions
	{
		public static MvcHtmlString LabelFor(this HtmlHelper<AddressModel> html, AddressFieldModel field, Func<string, string> labelResolver = null)
		{
			if (html == null) throw new ArgumentNullException(nameof(html));
			if (field == null) throw new ArgumentNullException(nameof(field));

			var name = field.Name;

			if (labelResolver == null)
			{
				name = name.Replace("_", " ");
				name = name.First().ToString().ToUpper() + name.Substring(1);
			}
			else
			{
				name = labelResolver(name);
			}

			return html.LabelFor(field.Expression, name);
		}

		public static MvcHtmlString InputFor(this HtmlHelper<AddressModel> htmlHelper, AddressFieldModel field, int? index = null)
		{
			if (htmlHelper == null) throw new ArgumentNullException(nameof(htmlHelper));
			if (field == null) throw new ArgumentNullException(nameof(field));

			switch (field.Field)
			{
				case AddressFieldKey.N:
				case AddressFieldKey.O:
				case AddressFieldKey.Z:
				case AddressFieldKey.X:
				case AddressFieldKey.A:
					return htmlHelper.TextBoxFor(field.Expression);
				case AddressFieldKey.D:
					return htmlHelper.ViewData.Model.SelectItems.DependentLocality.Any()
						? htmlHelper.DropDownListFor(field.Expression, htmlHelper.ViewData.Model.SelectItems.DependentLocality)
						: htmlHelper.TextBoxFor(field.Expression);
				case AddressFieldKey.C:
					return htmlHelper.ViewData.Model.SelectItems.Locality.Any()
						? htmlHelper.DropDownListFor(field.Expression, htmlHelper.ViewData.Model.SelectItems.Locality)
						: htmlHelper.TextBoxFor(field.Expression);
				case AddressFieldKey.S:
					return htmlHelper.ViewData.Model.SelectItems.AdministrativeArea.Any()
						? htmlHelper.DropDownListFor(field.Expression, htmlHelper.ViewData.Model.SelectItems.AdministrativeArea)
						: htmlHelper.TextBoxFor(field.Expression);
				case AddressFieldKey.Country:
					return htmlHelper.DropDownListFor(field.Expression, htmlHelper.ViewData.Model.SelectItems.Country);
				case AddressFieldKey.Language:
					return htmlHelper.HiddenFor(field.Expression);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
