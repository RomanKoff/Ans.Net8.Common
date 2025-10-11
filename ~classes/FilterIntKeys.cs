namespace Ans.Net8.Common
{

	public class FilterIntKeys
	{

		/* ctor */


		/// <param name="filter">
		/// '*' в начале строки — операция OR, иначе AND
		/// </param>
		public FilterIntKeys(
			string filter)
		{
			var filter1 = new FilterKeys(filter);
			UseOr = filter1.UseOr;
			Keys = [.. filter1.Keys.Select(x => x.ToInt(0))];
		}


		/* readonly properties */


		public IEnumerable<int> Keys { get; }
		public bool UseOr { get; }

	}

}
