using System;
using System.Collections.Generic;
using System.Globalization;

namespace I18N.Address
{
	public class AddressModel
	{
		public AddressModel(Country country, Language language)
		{
			Language = language;
			Country = country;
			AddressLine = new List<string>();
		}

		public AddressModel(CultureInfo culture)
		{
			if (culture == null)
				throw new ArgumentNullException(nameof(culture));

			Language = new Language(culture.TwoLetterISOLanguageName);

			var region = new RegionInfo(culture.Name);

			Country = new Country(region.TwoLetterISORegionName);
			AddressLine = new List<string>();
		}

		public string Name { get; set; }
		public string Organisation { get; set; }
		public ICollection<string> AddressLine { get; }
		public string City { get; set; }
		public string DependentLocality { get; set; }
		public string AdministrativeArea { get; set; }
		public string PostalCode { get; set; }
		public string SortingCode { get; set; }
		public Country Country { get; }
		public Language Language { get; }
	}
}