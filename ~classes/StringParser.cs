namespace Ans.Net8.Common
{

	public class StringParser
	{

		private readonly string[] _items;
		private readonly int _count;


		/* ctor */


		public StringParser(
			string source)
		{
			if (string.IsNullOrEmpty(source))
				return;
			_items = source.Split('|');
			_count = _items.Length;
		}


		/* functions */


		public string Get(
			int index,
			string defaultValue = null)
		{
			if (index < _count)
				return _items[index];
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
			return Get(index).ToDateTime();
		}


		public DateTime GetDateTime(
			int index,
			DateTime defaultValue)
		{
			return Get(index).ToDateTime(defaultValue);
		}


		public DateOnly? GetDateOnly(
			int index)
		{
			return Get(index).ToDateOnly();
		}


		public DateOnly GetDateOnly(
			int index,
			DateOnly defaultValue)
		{
			return Get(index).ToDateOnly(defaultValue);
		}


		public TimeOnly? GetTimeOnly(
			int index)
		{
			return Get(index).ToTimeOnly();
		}


		public TimeOnly GetTimeOnly(
			int index,
			TimeOnly defaultValue)
		{
			return Get(index).ToTimeOnly(defaultValue);
		}

	}

}
