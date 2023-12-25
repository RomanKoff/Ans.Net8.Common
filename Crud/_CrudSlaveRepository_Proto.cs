using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ans.Net8.Common.Crud
{

	public interface ISlaveEntity
		: IMasterEntity
	{
		int MasterPtr { get; set; }
	}



	public interface ICrudSlaveRepository<TSlaveEntity>
		: ICrudRepository<TSlaveEntity>
		where TSlaveEntity : class, ISlaveEntity
	{
		IEnumerable<TSlaveEntity> GetItems(
			Expression<Func<TSlaveEntity, bool>> filter, int ptr, string order, bool isDescending);
		TSlaveEntity GetNew(int ptr);
	}



	public abstract class _CrudSlaveRepository_Proto<TSlaveEntity>(
		DbContext db)
		: _CrudRepository_Base<TSlaveEntity>(db),
		ICrudSlaveRepository<TSlaveEntity>
		where TSlaveEntity : class, ISlaveEntity
	{

		/* functions */


		public virtual IEnumerable<TSlaveEntity> GetItems(
			Expression<Func<TSlaveEntity, bool>> filter,
			int ptr,
			string order,
			bool isDescending)
		{
			if (order == null)
			{
				order = DefaultOrder ?? "Id";
				isDescending = IsDefaultOrderDescending;
			}
			if (filter == null)
				filter = x => x.MasterPtr == ptr;
			else
				filter.And(x => x.MasterPtr == ptr);
			return GetItemsAsQueryable(
				filter, order, isDescending)
					.ToList();
		}


		public abstract TSlaveEntity GetNew(int ptr);

	}

}
