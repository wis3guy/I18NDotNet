using System.Linq;

namespace I18N.Address
{
	public struct AddressDataKey
	{
		private readonly Country _country;
		private string _dependentLocality;
		private Language? _language;
		private string _administrativeArea;
		private string _locality;

		public AddressDataKey(Country country)
		{
			_country = country;
			_administrativeArea = null;
			_locality = null;
			_dependentLocality = null;
			_language = null;
		}

		public void SetLanguage(Language language)
		{
			_language = language;
		}

		public void SetAdministrativeArea(string administrativeArea)
		{
			_administrativeArea = administrativeArea;
			_locality = null;
			_dependentLocality = null;
		}

		public void SetLocality(string locality)
		{
			_locality = locality;
			_dependentLocality = null;
		}

		public void SetDependentLocality(string dependentLocality)
		{
			_dependentLocality = dependentLocality;
		}

		public override string ToString()
		{
			var key = string.Join("/", new[] {_country.Code, _administrativeArea, _locality, _dependentLocality}.Where(x => x != null));

			if (_language.HasValue)
				key = $"{key}--{_language.Value.Code}";

			return key;
		}
	}
}