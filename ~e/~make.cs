namespace Ans.Net8.Common
{

	public static partial class _e
	{

		/*
		 * string Make(this string value, string template);
		 * string Make(this string value, string template, params object[] addons);
		 * string Make(this string value, string template, string nullValue);
		 * 
		 * string Make(this int value, string template, string format = null);
		 * string Make(this int value, string template, string format, int nullValue);
		 * string Make(this int? value, string template, string format = null);
		 * 
		 * string Make(this long value, string template, string format = null);
		 * string Make(this long value, string template, string format, long nullValue);
		 * string Make(this long? value, string template, string format = null);
		 * 
		 * string Make(this double value, string template, string format = null);
		 * string Make(this double value, string template, string format, double nullValue);
		 * string Make(this double? value, string template, string format = null);
		 * 
		 * string Make(this float value, string template, string format = null);
		 * string Make(this float value, string template, string format, float nullValue);
		 * string Make(this float? value, string template, string format = null);
		 * 
		 * string Make(this decimal value, string template, string format = null);
		 * string Make(this decimal value, string template, string format, decimal nullValue);
		 * string Make(this decimal? value, string template, string format = null);
		 * 
		 * string Make(this DateTime value, string template, string format = null);
		 * string Make(this DateTime value, string template, string format, DateTime nullValue);
		 * string Make(this DateTime? value, string template, string format = null);
		 * 
		 * string Make(this DateOnly value, string template, string format = null);
		 * string Make(this DateOnly value, string template, string format, DateOnly nullValue);
		 * string Make(this DateOnly? value, string template, string format = null);
		 * 
		 * string Make(this TimeOnly value, string template, string format = null);
		 * string Make(this TimeOnly value, string template, string format, TimeOnly nullValue);
		 * string Make(this TimeOnly? value, string template, string format = null);
		 * 
		 * string Make(this bool value, string trueText, string falseText = null);
		 * string Make(this bool value, string template, params object[] args);
		 * 
		 * string MakeRepeats(this string value, int count, string resultTemplate = null, string itemTemplate = null, string itemsSeparator = null);
		 * 
		 * string MakeFromCollection(this IEnumerable<string> items, string resultTemplate, string itemTemplate, string itemsSeparator);
		 * string MakeFromCollection<T>(this IEnumerable<T> items, Func<T, string> itemExtractor, string resultTemplate, string itemTemplate, string itemsSeparator);
		 * 
		 * string MakeOverDict<T>(this string key, DictHelper<T> dict, Func<T, string> func, string template);
		 * string MakeOverDict(this string key, DictHelper<string> dict, string template);
		 * 
		 * string Make_UrlWrapper(this string url, string template);
		 * 
		 * string Make_Passed(this DateTime datetime, DateTimeHelper calc, bool addTime, bool useYesterdayTodayTomorrow);
		 * string Make_Passed(this DateTime? datetime, DateTimeHelper calc, bool addTime, bool useYesterdayTodayTomorrow = true);
		 * string Make_Passed(this DateOnly date, DateTimeHelper calc, bool useYesterdayTodayTomorrow);
		 * string Make_Passed(this DateOnly? date, DateTimeHelper calc, bool useYesterdayTodayTomorrow = true);
		 * 
		 * string Make_Span(this DateTime datetime1, DateTime? datetime2, bool showCurrentYear = false);
		 * string Make_Span(this DateOnly date1, DateOnly? date2, bool showCurrentYear = false);
		 * 
		 * string Make_UniDate(this DateTime value);
		 * string Make_SpecDate(this DateTime value);
		 * string Make_SpecDate(this DateTime value);
		 * 
		 * string Make_SizeOfKB(this int size);
		 * string Make_SizeOfKB(this long size);
		 */


		public static string Make(
			this string value,
			string template)
		{
			return string.IsNullOrEmpty(value)
				? null : string.IsNullOrEmpty(template)
					? value : string.Format(template, value);
		}
		public static string Make(
			this string value,
			string template,
			params object[] addons)
		{
			return string.IsNullOrEmpty(value)
				? null : string.IsNullOrEmpty(template)
					? value : string.Format(template, addons.Insert(0, value));
		}
		public static string Make(
			this string value,
			string template,
			string nullValue)
		{
			return value == nullValue
				? null : string.Format(template, value);
		}


		public static string Make(
			this int value,
			string template,
			string format = null)
		{
			return string.IsNullOrEmpty(format)
				? value.ToString()
				: value.ToString(format).Make(template);
		}
		public static string Make(
			this int value,
			string template,
			string format,
			int nullValue)
		{
			return value == nullValue
				? null : value.Make(template, format);
		}
		public static string Make(
			this int? value,
			string template,
			string format = null)
		{
			return value?.Make(format, template);
		}


		public static string Make(
			this long value,
			string template,
			string format = null)
		{
			return string.IsNullOrEmpty(format)
				? value.ToString()
				: value.ToString(format).Make(template);
		}
		public static string Make(
			this long value,
			string template,
			string format,
			long nullValue)
		{
			return value == nullValue
				? null : value.Make(template, format);
		}
		public static string Make(
			this long? value,
			string template,
			string format = null)
		{
			return value?.Make(format, template);
		}


		public static string Make(
			this double value,
			string template,
			string format = null)
		{
			return string.IsNullOrEmpty(format)
				? value.ToString()
				: value.ToString(format).Make(template);
		}
		public static string Make(
			this double value,
			string template,
			string format,
			double nullValue)
		{
			return value == nullValue
				? null : value.Make(template, format);
		}
		public static string Make(
			this double? value,
			string template,
			string format = null)
		{
			return value?.Make(format, template);
		}


		public static string Make(
			this float value,
			string template,
			string format = null)
		{
			return string.IsNullOrEmpty(format)
				? value.ToString()
				: value.ToString(format).Make(template);
		}
		public static string Make(
			this float value,
			string template,
			string format,
			float nullValue)
		{
			return value == nullValue
				? null : value.Make(template, format);
		}
		public static string Make(
			this float? value,
			string template,
			string format = null)
		{
			return value?.Make(format, template);
		}


		public static string Make(
			this decimal value,
			string template,
			string format = null)
		{
			return string.IsNullOrEmpty(format)
				? value.ToString()
				: value.ToString(format).Make(template);
		}
		public static string Make(
			this decimal value,
			string template,
			string format,
			decimal nullValue)
		{
			return value == nullValue
				? null : value.Make(template, format);
		}
		public static string Make(
			this decimal? value,
			string template,
			string format = null)
		{
			return value?.Make(format, template);
		}


		public static string Make(
			this DateTime value,
			string template,
			string format = null)
		{
			return string.IsNullOrEmpty(format)
				? value.ToString()
				: value.ToString(format).Make(template);
		}
		public static string Make(
			this DateTime value,
			string template,
			string format,
			DateTime nullValue)
		{
			return value == nullValue
				? null : value.Make(template, format);
		}
		public static string Make(
			this DateTime? value,
			string template,
			string format = null)
		{
			return value?.Make(format, template);
		}


		public static string Make(
			this DateOnly value,
			string template,
			string format = null)
		{
			return string.IsNullOrEmpty(format)
				? value.ToString()
				: value.ToString(format).Make(template);
		}
		public static string Make(
			this DateOnly value,
			string template,
			string format,
			DateOnly nullValue)
		{
			return value == nullValue
				? null : value.Make(template, format);
		}
		public static string Make(
			this DateOnly? value,
			string template,
			string format = null)
		{
			return value?.Make(format, template);
		}


		public static string Make(
			this TimeOnly value,
			string template,
			string format = null)
		{
			return string.IsNullOrEmpty(format)
				? value.ToString()
				: value.ToString(format).Make(template);
		}
		public static string Make(
			this TimeOnly value,
			string template,
			string format,
			TimeOnly nullValue)
		{
			return value == nullValue
				? null : value.Make(template, format);
		}
		public static string Make(
			this TimeOnly? value,
			string template,
			string format = null)
		{
			return value?.Make(format, template);
		}


		public static string Make(
			this bool value,
			string trueText,
			string falseText = null)
		{
			return value
				? trueText : falseText;
		}
		public static string Make(
			this bool value,
			string template,
			params object[] args)
		{
			return value
				? string.Format(template, args) : null;
		}


		public static string MakeRepeats(
			this string value,
			int count,
			string resultTemplate = null,
			string itemTemplate = null,
			string itemsSeparator = null)
		{
			if (string.IsNullOrEmpty(value) || count < 1)
				return null;
			var s1 = value.Make(itemTemplate);
			var a1 = Enumerable.Repeat(s1, count);
			return string.Join(itemsSeparator, a1)
				.Make(resultTemplate);
		}


		public static string MakeFromCollection(
			this IEnumerable<string> items,
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator)
		{
			if (!(items?.Count() > 0))
				return null;
			Func<string, string> func1 = string.IsNullOrEmpty(itemTemplate)
				? x => x : x => x.Make(itemTemplate);
			var a1 = items.Select(func1);
			return string.Join(itemsSeparator, a1)
				.Make(resultTemplate);
		}
		public static string MakeFromCollection<T>(
			this IEnumerable<T> items,
			Func<T, string> itemExtractor,
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator)
		{
			return MakeFromCollection(
				items.Select(itemExtractor), resultTemplate, itemTemplate, itemsSeparator);
		}


		public static string MakeOverDict<T>(
			this string key,
			DictHelper<T> dict,
			Func<T, string> func,
			string template)
		{
			return string.IsNullOrEmpty(key)
				? null : dict.GetPropertyOrKey(key, func).Make(template);
		}
		public static string MakeOverDict(
			this string key,
			DictHelper<string> dict,
			string template)
		{
			return MakeOverDict(
				key, dict, x => x, template);
		}


		public static string Make_UrlWrapper(
			this string url,
			string template)
		{
			if (string.IsNullOrEmpty(url))
				return null;
			if (url[0] == '/'
				|| url.StartsWith("https://")
				|| url.StartsWith("http://"))
				return url.Make(template);
			return string.Concat("https://", url).Make(template);
		}


		public static string Make_Passed(
			this DateTime datetime,
			DateTimeHelper calc,
			bool addTime,
			bool useYesterdayTodayTomorrow)
		{
			return calc.GetPassed(
				datetime, addTime, useYesterdayTodayTomorrow);
		}
		public static string Make_Passed(
			this DateTime? datetime,
			DateTimeHelper calc,
			bool addTime,
			bool useYesterdayTodayTomorrow = true)
		{
			return calc.GetPassed(
				datetime, addTime, useYesterdayTodayTomorrow);
		}


		public static string Make_Passed(
			this DateOnly date,
			DateTimeHelper calc,
			bool useYesterdayTodayTomorrow)
		{
			return calc.GetPassed(
				date, false, useYesterdayTodayTomorrow);
		}
		public static string Make_Passed(
			this DateOnly? date,
			DateTimeHelper calc,
			bool useYesterdayTodayTomorrow = true)
		{
			return calc.GetPassed(
				date, false, useYesterdayTodayTomorrow);
		}


		public static string Make_Span(
			this DateTime datetime1,
			DateTime? datetime2,
			bool showCurrentYear = false)
		{
			return SuppDateTime.GetSpan(
				datetime1, datetime2, showCurrentYear);
		}
		public static string Make_Span(
			this DateOnly date1,
			DateOnly? date2,
			bool showCurrentYear = false)
		{
			return SuppDateTime.GetSpan(
				date1, date2, showCurrentYear);
		}


		public static string Make_UniDate(
			this DateTime value)
		{
			return value.ToString("yyyy-MM-dd");
		}
		public static string Make_SpecDate(
			this DateTime value)
		{
			return value.ToString("yyyy-0MM-dd");
		}


		public static string Make_SizeOfKB(
			this int size)
		{
			return ((long)size).Make_SizeOfKB();
		}
		public static string Make_SizeOfKB(
			this long size)
		{
			return SuppIO.GetSizeOfKB(size);
		}





		/*
		public static string MakeFromRegistry(
			this string value,
			Registry registry,
			string template = null,
			string nullValue = null)
		{
			if (string.IsNullOrEmpty(value) || value == nullValue)
				return res_Common.Text_NullItem;
			return SuppMake.MakeFromRegistry(value, registry, template);
		}
		public static string MakeFromRegistry(
			string value,
			Registry registry,
			string template)
		{
			if (registry == null)
				return "{" + value + "}";
			var item = registry.GetItem(value);
			return (item == null)
				? res_Common.Text_ErrorItem
				: Make(item.Value, template);
		}
		*/

	}

}
