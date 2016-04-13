using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using I18N.Address;

namespace I18NDotNet.Address.Mvc
{
	public static class AddressModelExtensions
	{
		public static Expression<Func<TModel, TProperty>> GetExpression<TModel, TProperty>(this IAddress address, AddressFieldKey key)
		{
			return null;
		}
	}
}
