namespace Ans.Net8.Common
{

	public class DictParser
		: Dictionary<string, string>
	{

		public string Get(
			string key)
		{
			var value1 = (TryGetValue(key, out var value2))
				? value2.ToString() : null;
			return (string.IsNullOrEmpty(value1))
				? null : value1;
		}


		public int? GetInt(
			string key)
		{
			return Get(key).ToInt();
		}


		public int GetInt(
			string key,
			int defaultValue)
		{
			return Get(key).ToInt(defaultValue);
		}


		public long? GetLong(
			string key)
		{
			return Get(key).ToLong();
		}


		public long GetLong(
			string key,
			long defaultValue)
		{
			return Get(key).ToLong(defaultValue);
		}


		public double? GetDouble(
			string key)
		{
			return Get(key).ToDouble();
		}


		public double GetDouble(
			string key,
			double defaultValue)
		{
			return Get(key).ToDouble(defaultValue);
		}


		public bool GetBool(
			string key)
		{
			return Get(key).ToBool();
		}


		public DateTime? GetDateTime(
			string key)
		{
			return Get(key).ToDateTime();
		}


		public DateTime GetDateTime(
			string key,
			DateTime defaultValue)
		{
			return Get(key).ToDateTime(defaultValue);
		}


		public DateOnly? GetDateOnly(
			string key)
		{
			return Get(key).ToDateOnly();
		}


		public DateOnly GetDateOnly(
			string key,
			DateOnly defaultValue)
		{
			return Get(key).ToDateOnly(defaultValue);
		}


		public TimeOnly? GetTimeOnly(
			string key)
		{
			return Get(key).ToTimeOnly();
		}


		public TimeOnly GetTimeOnly(
			string key,
			TimeOnly defaultValue)
		{
			return Get(key).ToTimeOnly(defaultValue);
		}

	}

}
