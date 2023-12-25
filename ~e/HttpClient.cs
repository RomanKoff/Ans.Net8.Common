namespace Ans.Net8.Common
{

	public static partial class _e
	{

		/*
		 * DictHelper<T> GetDict<T>(this HttpClient client, string url);
		 */


		public static DictHelper<T> GetDict<T>(
			this HttpClient client,
			string url)
		{
			return new WebApiHelper<DictHelper<T>>(
				client, url)
					.SendQuery().Content;
		}

	}

}
