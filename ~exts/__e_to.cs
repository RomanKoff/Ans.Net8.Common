namespace Ans.Net8.Common
{

	public static partial class __e_to
	{

		/* functions */


		public static IDictionary<string, string> ToStringDictionary(
			this IEnumerable<string> source)
		{
			if (!(source?.Count() > 0))
				return null;
			var dict1 = new Dictionary<string, string>();
			foreach (var item1 in source)
			{
				var a1 = item1.Split('=');
				if (a1.Length == 2)
					dict1.Add(a1[0], a1[1]);
			}
			return dict1;
		}


		public static IEnumerable<IEnumerable<T>> ToGrid<T>(
			this IEnumerable<T> source,
			int count)
		{
			return source
				.Select((x, y) => new { Index = y, Value = x })
				.GroupBy(x => x.Index / count)
				.Select(x => x.Select(y => y.Value));
		}


		public static int[] ToIntArray(
			this string[] source)
		{
			return [.. source.Select(x => x.ToInt(0))];
		}


		public static int[] ToIntArray(
			this string source)
		{
			return (string.IsNullOrEmpty(source))
				? null
				: source.Split(_Consts.SEPS_ARRAY).ToIntArray();
		}


		public static int ToIntRound(
			this double value)
		{
			return (int)(value + .5d);
		}


		public static int ToIntRound(
			this float value)
		{
			return (int)(value + .5f);
		}


		public static int ToIntRound(
			this decimal value)
		{
			return (int)(value + .5m);
		}


		public static int? ToInt(
			this string value)
		{
			if (int.TryParse(value, out int v1))
				return v1;
			return null;
		}
		public static int ToInt(
			this string value,
			int defaultValue)
		{
			return value.ToInt() ?? defaultValue;
		}


		public static uint? ToUInt(
			this string value)
		{
			if (uint.TryParse(value, out uint v1))
				return v1;
			return null;
		}
		public static uint ToUInt(
			this string value,
			uint defaultValue)
		{
			return value.ToUInt() ?? defaultValue;
		}


		public static long? ToLong(
			this string value)
		{
			if (long.TryParse(value, out long v1))
				return v1;
			return null;
		}
		public static long ToLong(
			this string value,
			long defaultValue)
		{
			return value.ToLong() ?? defaultValue;
		}


		public static double? ToDouble(
			this string value)
		{
			if (double.TryParse(value, out double v1))
				return v1;
			return null;
		}
		public static double ToDouble(
			this string value,
			double defaultValue)
		{
			return value.ToDouble() ?? defaultValue;
		}


		public static float? ToFloat(
			this string value)
		{
			if (float.TryParse(value, out float v1))
				return v1;
			return null;
		}
		public static float ToFloat(
			this string value,
			float defaultValue)
		{
			return value.ToFloat() ?? defaultValue;
		}


		public static decimal? ToDecimal(
			this string value)
		{
			if (decimal.TryParse(value, out decimal v1))
				return v1;
			return null;
		}
		public static decimal ToDecimal(
			this string value,
			decimal defaultValue)
		{
			return value.ToDecimal() ?? defaultValue;
		}


		public static bool ToBool(
			this string value)
		{
			if (value == null || value.Length > 4)
				return false;
			if (value.Length < 4)
				return value == "1";
			return value == "true"
				|| value == "True"
				|| value == "TRUE";
		}

	}

}
