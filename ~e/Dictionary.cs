namespace Ans.Net8.Common
{

	public static partial class _e
	{

		/*
         * T GetValue<T>(this Dictionary<string, T> dictionary, string key, T defaultValue);
         * 
         * string GetString(this Dictionary<string, string> dictionary, string key, string defaultValue);
         * string GetString(this Dictionary<int, string> dictionary, int key, string defaultValue);
         * 
         * int GetInt(this Dictionary<string, string> dictionary, string key, int defaultValue);
         * int GetInt(this Dictionary<int, string> dictionary, int key, int defaultValue);
         */


		public static T GetValue<T>(
			this Dictionary<string, T> dictionary,
			string key,
			T defaultValue)
		{
			return dictionary.TryGetValue(key, out T value1)
				? value1 : defaultValue;
		}


		public static string GetString(
			this Dictionary<string, string> dictionary,
			string key,
			string defaultValue)
		{
			return dictionary.TryGetValue(key, out string value1)
				 ? value1 : defaultValue;
		}
		public static string GetString(
			this Dictionary<int, string> dictionary,
			int key,
			string defaultValue)
		{
			return dictionary.TryGetValue(key, out string value1)
				? value1 : defaultValue;
		}


		public static int GetInt(
			this Dictionary<string, string> dictionary,
			string key,
			int defaultValue)
		{
			return dictionary.TryGetValue(key, out string value1)
				? value1.ToInt(defaultValue) : defaultValue;
		}
		public static int GetInt(
			this Dictionary<int, string> dictionary,
			int key,
			int defaultValue)
		{
			return dictionary.TryGetValue(key, out string value1)
				? value1.ToInt(defaultValue) : defaultValue;
		}

	}

}
