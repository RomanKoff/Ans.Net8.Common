namespace Ans.Net8.Common
{

	public class FilterKeys
	{

		/* ctor */


		/// <param name="filter">
		/// '*' в начале строки — операция OR, иначе AND
		/// </param>
		public FilterKeys(
			string filter)
		{
			if (!string.IsNullOrEmpty(filter))
			{
				string s1;
				if (filter[0] == '*')
				{
					s1 = filter[1..];
					UseOr = true;
				}
				else
					s1 = filter;
				Keys = s1.Split([';', ',']);
			}
		}


		/* readonly properties */


		public IEnumerable<string> Keys { get; }
		public bool UseOr { get; }

	}

}
