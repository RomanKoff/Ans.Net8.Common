namespace Ans.Net8.Common
{

	public class StringParser
	{

		private readonly string[] _items;
		private readonly int _count;


		/* ctor */


		public StringParser(
			string source,
			char separator)
		{
			if (string.IsNullOrEmpty(source))
				return;
			_items = source.Split(separator);
			_count = _items.Length;
		}


		public StringParser(
			string source,
			string separator = null)
		{
			if (string.IsNullOrEmpty(source))
				return;
			_items = separator == null
				? source.Split('|')
				: source.Split(separator);
			_count = _items.Length;
		}


		/* functions */


		public string Get(
			int index,
			string defaultValue = null)
		{
			if (index < _count)
			{
				var s1 = _items[index];
				return string.IsNullOrEmpty(s1) ? defaultValue : s1;
			}
			return defaultValue;
		}


		public int? GetInt(
			int index)
		{
			return Get(index).ToInt();
		}
		public int GetInt(
			int index,
			int defaultValue)
		{
			return Get(index).ToInt(defaultValue);
		}


		public bool GetBool(
			int index)
		{
			return Get(index).ToBool();
		}


		public DateTime? GetDateTime(
			int index)
		{
			return SuppDateTime.GetDateTime(Get(index));
		}
		public DateTime GetDateTime(
			int index,
			DateTime defaultValue)
		{
			return GetDateTime(index) ?? defaultValue;
		}
		public string GetDateTime(
			int index,
			string format)
		{
			return GetDateTime(index)?.ToString(format);
		}


		public DateOnly? GetDateOnly(
			int index)
		{
			return SuppDateTime.GetDateOnly(Get(index));
		}
		public DateOnly GetDateOnly(
			int index,
			DateOnly defaultValue)
		{
			return GetDateOnly(index) ?? defaultValue;
		}
		public string GetDateOnly(
			int index,
			string format)
		{
			return GetDateOnly(index)?.ToString(format);
		}


		public TimeOnly? GetTimeOnly(
			int index)
		{
			return SuppDateTime.GetTimeOnly(Get(index));
		}
		public TimeOnly GetTimeOnly(
			int index,
			TimeOnly defaultValue)
		{
			return GetTimeOnly(index) ?? defaultValue;
		}
		public string GetTimeOnly(
			int index,
			string format)
		{
			return GetTimeOnly(index)?.ToString(format);
		}

	}

}
