using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ans.Net8.Common.Crud
{

	public interface IMasterEntity
	{
		int Id { get; set; }
	}



	public interface ICrudMasterRepository<TMasterEntity>
		: ICrudRepository<TMasterEntity>
		where TMasterEntity : class, IMasterEntity
	{
		IEnumerable<TMasterEntity> GetItems(
			Expression<Func<TMasterEntity, bool>> filter, string order, bool isDescending);
		TMasterEntity GetNew();
	}



	public abstract class _CrudMasterRepository_Proto<TMasterEntity>(
			DbContext db)
		: _CrudRepository_Base<TMasterEntity>(db),
		ICrudMasterRepository<TMasterEntity>
		where TMasterEntity : class, IMasterEntity
	{


		/* functions */


		public virtual IEnumerable<TMasterEntity> GetItems(
			Expression<Func<TMasterEntity, bool>> filter,
			string order,
			bool isDescending)
		{
			if (order == null)
			{
				order = DefaultOrder ?? "Id";
				isDescending = IsDefaultOrderDescending;
			}
			return GetItemsAsQueryable(
				filter, order, isDescending)
					.ToList();
		}


		public abstract TMasterEntity GetNew();

	}

}
