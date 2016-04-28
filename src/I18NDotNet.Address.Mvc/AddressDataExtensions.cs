using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public static class AddressDataExtensions
	{
		private static readonly Regex FormatFieldRegex = new Regex(@"%([A-Z])\b");

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
					Value = keys[i],
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

		public static AddressFieldModel[] GetFields(this AddressData data, SelectItemsModel selectItems)
		{
			if (!data.ContainsKey(AddressData.Properties.Format))
				return new AddressFieldModel[0];

			var result = new List<AddressFieldModel>();

			var format = FormatFieldRegex.Matches(data[AddressData.Properties.Format])
				.Cast<Match>()
				.Select(match => match.Groups[1].Value)
				.ToArray();

			foreach (var field in format)
			{
				AddressFieldKey parsed;

				if (Enum.TryParse(field, out parsed))
				{
					result.Add(new AddressFieldModel
					{
						Field = parsed,
						Name = data.GetName(parsed),
						Expression = GetExpression(parsed, result.Count(x => x.Field == parsed))
					});
				}
			}

			if (data.ContainsKey(AddressData.Properties.RequiredFields))
			{
				var required = data[AddressData.Properties.RequiredFields].ToCharArray().Select(x => x.ToString()).ToArray();

				foreach (var field in required)
				{
					AddressFieldKey parsed;

					if (!Enum.TryParse(field, out parsed))
						continue;

					foreach (var fieldModel in result.Where(x => x.Field == parsed))
						fieldModel.Required = true;
				}
			}

			//if (selectItems.AdministrativeArea.Any() &&
			//	result.All(x => x.Field != AddressFieldKey.S))
			//	result.Add(new AddressFieldModel { Field = AddressFieldKey.S });

			//if (selectItems.Locality.Any() &&
			//	result.All(x => x.Field != AddressFieldKey.C))
			//	result.Add(new AddressFieldModel { Field = AddressFieldKey.C });

			//if (selectItems.DependentLocality.Any() &&
			//	result.All(x => x.Field != AddressFieldKey.D))
			//	result.Add(new AddressFieldModel { Field = AddressFieldKey.D });

			result.Add(new AddressFieldModel {Field = AddressFieldKey.Country, Name = data.GetName(AddressFieldKey.Country), Expression = x => x.CountryCode});
			result.Add(new AddressFieldModel {Field = AddressFieldKey.Language, Name = data.GetName(AddressFieldKey.Country), Expression = x => x.LanguageCode});

			return result.ToArray();
		}

		private static Expression<Func<AddressModel, string>> GetExpression(AddressFieldKey parsed, int index)
		{
			switch (parsed)
			{
				case AddressFieldKey.N:
					return x => x.Name;
				case AddressFieldKey.O:
					return x => x.Organisation;
				case AddressFieldKey.A:
					return x => x.AddressLine[index];
				case AddressFieldKey.D:
					return x => x.DependentLocality;
				case AddressFieldKey.C:
					return x => x.Locality;
				case AddressFieldKey.S:
					return x => x.AdministrativeArea;
				case AddressFieldKey.Z:
					return x => x.PostalCode;
				case AddressFieldKey.X:
					return x => x.SortingCode;
				case AddressFieldKey.Country:
					return x => x.CountryCode;
				case AddressFieldKey.Language:
					return x => x.LanguageCode;
				default:
					throw new ArgumentOutOfRangeException(nameof(parsed), parsed, null);
			}
		}

		private static string GetName(this AddressData data, AddressFieldKey parsed)
		{
			// TODO: Not sure this is the right place for this logic? Perhaps it should be in the core project?

			switch (parsed)
			{
				case AddressFieldKey.N:
					return "name";
				case AddressFieldKey.O:
					return "organization";
				case AddressFieldKey.A:
					return "address_line";
				case AddressFieldKey.D:
					return data.ContainsKey(AddressData.Properties.DependentLocalityNameType) ? data[AddressData.Properties.DependentLocalityNameType] : "dependent_locality";
				case AddressFieldKey.C:
					return data.ContainsKey(AddressData.Properties.LocalityNameType) ? data[AddressData.Properties.LocalityNameType] : "locality";
				case AddressFieldKey.S:
					return data.ContainsKey(AddressData.Properties.AdministrativeAreaNameType) ? data[AddressData.Properties.AdministrativeAreaNameType] : "administrative_area";
				case AddressFieldKey.Z:
					return data.ContainsKey(AddressData.Properties.ZipNameType) ? data[AddressData.Properties.ZipNameType] : "postal_code";
				case AddressFieldKey.X:
					return "sorting_code";
				case AddressFieldKey.Country:
					return "country";
				case AddressFieldKey.Language:
					return "language";
				default:
					throw new ArgumentOutOfRangeException(nameof(parsed), parsed, null);
			}
		}
	}
}