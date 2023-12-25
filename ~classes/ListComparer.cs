namespace Ans.Net8.Common
{

	public class ListComparer<T>(
		IEnumerable<T> currentList,
		IEnumerable<T> newestList,
		Func<T, string> compareValue,
		Func<T, bool> removeTest = null)
		: _ListComparer_Base<T>(
			currentList, newestList,
			(x1, x2) => compareValue(x1).Equals(compareValue(x2)),
			(x1, x2) => !compareValue(x1).Equals(compareValue(x2)),
			removeTest)
	{
	}

}
