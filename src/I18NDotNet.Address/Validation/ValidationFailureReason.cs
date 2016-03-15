namespace I18N.Address.Validation
{
	public enum ValidationFailureReason
	{
		/// <summary>
		/// Missing required field value
		/// </summary>
		Required,

		/// <summary>
		/// Invalid value format
		/// </summary>
		Invalid,

		/// <summary>
		/// Unexpected field
		/// </summary>
		Unexpected,

		/// <summary>
		/// Unknown field value
		/// </summary>
		Uknown
	}
}