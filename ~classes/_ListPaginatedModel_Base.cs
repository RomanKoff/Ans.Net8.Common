namespace Ans.Net8.Common
{

	public class _ListPaginatedModel_Base<TEntity, TModel>
		where TEntity : class
		where TModel : class
	{

		public _ListPaginatedModel_Base(
			IQueryable<TEntity> query,
			Func<TEntity, TModel> func,
			int page,
			int itemsOnPage)
		{
			var helper1 = new PaginatedQueryableHelper<TEntity>(
				query, page, itemsOnPage);
			Pagination = new PaginationModel(
				helper1.PaginationHelper);
			Items = helper1.Query
				.Select(func).AsEnumerable();
		}


		public PaginationModel Pagination { get; }
		public IEnumerable<TModel> Items { get; }

	}

}
