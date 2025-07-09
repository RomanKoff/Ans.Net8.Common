using System.Linq.Expressions;

namespace Ans.Net8.Common
{

	public static class SuppLinq
	{

		/* functions */


		public static Expression<Func<T, bool>> ApplyFilter_Add<T>(
			Expression<Func<T, bool>> filter,
			Expression<Func<T, bool>> expression)
		{
			return filter == null
				? expression : filter.And(expression);
		}

	}

}
