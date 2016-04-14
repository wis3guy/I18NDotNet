using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public static class AddressDataExtensions
	{
		public static SelectItemsModel GetSelectItems(this AddressData data)
		{
			return new SelectItemsModel
			{
				Country = GetCountryCandidates(),
				AdministrativeArea = data.GetSubregionCandidates(AddressDataContext.Country),
				Locality = data.GetSubregionCandidates(AddressDataContext.AdministrativeArea),
				DependentLocality = data.GetSubregionCandidates(AddressDataContext.Locality)
			};
		}

		private static IEnumerable<SelectListItem> GetSubregionCandidates(this AddressData data, AddressDataContext context)
		{
			if (data == null) throw new ArgumentNullException(nameof(data));

			if (!data.ContainsKey(context) ||
			    !data[context].ContainsKey(AddressData.Properties.SubRegionKeys) ||
			    !data[context].ContainsKey(AddressData.Properties.SubRegionNames))
				return new SelectListItem[0];

			var keys = data[context][AddressData.Properties.SubRegionKeys].Split(AddressData.ListItemDelimiter);
			var values = data[context][AddressData.Properties.SubRegionNames].Split(AddressData.ListItemDelimiter);

			var result = new List<SelectListItem>();

			for (var i = 0; i < keys.Length; i++)
			{
				result.Add(new SelectListItem
				{
					Value = values[i],
					Text = values[i]
				});
			}

			return result.ToArray();
		}

		private static IEnumerable<SelectListItem> GetCountryCandidates()
		{
			return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
				.Select(x => new RegionInfo(x.LCID))
				.Where(x => RegionDataConstants.ContainsCountry(x.TwoLetterISORegionName))
				.Distinct()
				.Select(region => new SelectListItem
				{
					Value = region.TwoLetterISORegionName,
					Text = region.EnglishName
				})
				.OrderBy(x => x.Text)
				.ToArray();
		}
	}
}