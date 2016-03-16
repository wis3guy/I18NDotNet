namespace I18N.Address
{
	public enum AddressFieldKey
	{
		/// <summary>
		/// Name
		/// </summary>
		N,

		/// <summary>
		/// Organisation
		/// </summary>
		O,

		/// <summary>
		/// Street Address Line(s) 
		/// </summary>
		A,

		/// <summary>
		/// Dependent locality (may be an inner-city district or a suburb)
		/// </summary>
		D,

		/// <summary>
		/// City or Locality
		/// </summary>
		C,

		/// <summary>
		/// Administrative area such as a state, province, island etc
		/// </summary>
		S,

		/// <summary>
		/// Zip or postal code
		/// </summary>
		Z,

		/// <summary>
		/// Sorting code
		/// </summary>
		X,

		/// <summary>
		/// Country (never part of the data received from google, as it is part of the key)
		/// </summary>
		Country,

		/// <summary>
		/// Optionl language of the address, used for region matching (never part of the data received from google, as it is part of the key)
		/// </summary>
		Language,

		/// <summary>
		/// Wether the address uses latin or local script (never part of the data received from google, as it is part of the key)
		/// </summary>
		Script
	}
}