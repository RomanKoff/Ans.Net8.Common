namespace Ans.Net8.Common
{

	public class DictHelper<T>
		: Dictionary<string, T>
	{

		public T GetItem(
			string key)
			=> this.GetValue(key, default);


		public string GetPropertyOrKey(
			string key,
			Func<T, string> func)
		{
			var item1 = GetItem(key);
			return (item1 == null)
				? key : func(item1);
		}

	}

}
