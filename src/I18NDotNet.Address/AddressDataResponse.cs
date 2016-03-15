using Newtonsoft.Json;

namespace I18N.Address
{
	public class AddressDataResponse
	{
		public string Id { get; set; }
		public string Key { get; set; }

		public string Require { get; set; }
		public string Name { get; set; }

		public string Upper { get; set; } // TODO: Needed?

		[JsonProperty(PropertyName = "lang")]
		public string Language { get; set; }

		public string Languages { get; set; }

		[JsonProperty(PropertyName = "fmt")]
		public string Format { get; set; }

		[JsonProperty(PropertyName = "state_name_type")]
		public string StateNameType { get; set; }

		//
		// ZIP

		[JsonProperty(PropertyName = "zip")]
		public string ZipRegex { get; set; }

		[JsonProperty(PropertyName = "zipex")]
		public string ZipExamples { get; set; }

		[JsonProperty(PropertyName = "sub_zips")]
		public string SubZips { get; set; }

		[JsonProperty(PropertyName = "sub_zipexs")]
		public string SubZipExamples { get; set; }

		[JsonProperty(PropertyName = "zip_name_type")]
		public string ZipNameType { get; set; }

		//
		// Sub

		[JsonProperty(PropertyName = "sub_keys")]
		public string SubKeys { get; set; }

		[JsonProperty(PropertyName = "sub_names")]
		public string SubNames { get; set; }


		public string PostUrl { get; set; } // TODO: Needed?

		[JsonProperty(PropertyName = "locality_name_type")]
		public string LocalityNameType { get; set; }

		[JsonProperty(PropertyName = "sublocality_name_type")]
		public string SubLocalityNameType { get; set; }

		public void ApplyDefaults(AddressDataResponse defaults)
		{
			Upper = Upper ?? defaults.Upper;
			ZipNameType = ZipNameType ?? defaults.ZipNameType;
			Require = Require ?? defaults.Require;
			StateNameType = StateNameType ?? defaults.StateNameType;
			LocalityNameType = LocalityNameType ?? defaults.LocalityNameType;
			SubLocalityNameType = SubLocalityNameType ?? defaults.SubLocalityNameType;
			Format = Format ?? defaults.Format;

			// TODO: This is not very flexible. Google might decide to add defaults to other properties which we wont pickup like this.
		}
	}
}