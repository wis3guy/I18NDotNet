using System;
using System.Linq.Expressions;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public class AddressFieldModel
	{
		public AddressFieldKey Field { get; set; }
		public bool Required { get; set; }
		public string Name { get; set; }
		public Expression<Func<AddressModel, string>> Expression { get; set; }
	}
}