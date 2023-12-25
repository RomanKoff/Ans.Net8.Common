namespace Ans.Net8.Common
{

	public static class SuppDateTime
	{

		/*
		 * string GetSpan(DateTime datetime1, DateTime? datetime2, bool showCurrentYear = false);
		 * string GetSpan(DateOnly date1, DateOnly? date2, bool showCurrentYear = false);
         * IEnumerable<DateTime> GetDays(DateTime start, DateTime end);
         * IEnumerable<DateTime> GetDays(DateOnly start, DateOnly end);
         * DateTime Max(DateTime value1, DateTime? value2);
         * DateTime Max(DateOnly value1, DateOnly? value2);
         * DateTime Min(DateTime value1, DateTime? value2);
         * DateTime Min(DateOnly value1, DateOnly? value2);
         */


		/// <summary>
		/// Возвращает диапазон дат (для блога)
		/// - одна или равные даты
		/// - разные года
		/// - разные месяцы года
		/// - разные дни месяца
		/// </summary>
		/// <param name="datetime1">Первая дата</param>
		/// <param name="datetime2">Вторая дата</param>
		/// <param name="showCurrentYear">Отображать текущий год</param>
		public static string GetSpan(
			DateTime datetime1,
			DateTime? datetime2,
			bool showCurrentYear = false)
		{
			// одна или равные даты
			if (datetime2 == null || datetime1.Date.Equals(datetime2.Value.Date))
				return (showCurrentYear)
					? datetime1.ToString(Resources.Common.Format_DateRange_Full)
					: datetime1.ToString(Resources.Common.Format_DateRange_WithinYear);
			DateTime d2 = datetime2.Value;
			if (datetime1 > d2)
				(datetime1, d2) = (d2, datetime1);
			if (datetime1.Year != d2.Year)
			{
				// разные года
				return string.Format("{0} – {1}",
					datetime1.ToString(Resources.Common.Format_DateRange_Full),
					d2.ToString(Resources.Common.Format_DateRange_Full));
			}
			if (datetime1.Month != d2.Month)
			{
				// разные месяцы года
				return string.Format("{0} – {1}",
					datetime1.ToString(Resources.Common.Format_DateRange_WithinYear),
					(showCurrentYear)
						? d2.ToString(Resources.Common.Format_DateRange_Full)
						: d2.ToString(Resources.Common.Format_DateRange_WithinYear));
			}
			// разные дни месяца
			return string.Format("{0}–{1}{2}",
				datetime1.ToString(Resources.Common.Format_DateSpanOfMonth_First),
				datetime2.Value.ToString(Resources.Common.Format_DateSpanOfMonth_Second),
				(showCurrentYear)
					? $", {datetime1.Year}"
					: null);
		}


		public static string GetSpan(
			DateOnly date1,
			DateOnly? date2,
			bool showCurrentYear = false)
		{
			return GetSpan(date1.GetDateTime(), date2?.GetDateTime(), showCurrentYear);
		}


		/// <summary>
		/// Возвращает перечень дней между от start до end
		/// </summary>
		public static IEnumerable<DateTime> GetDays(
			DateTime start,
			DateTime end)
		{
			return Enumerable.Range(0, end.Date.Subtract(start.Date).Days + 1)
				.Select(x => start.Date.AddDays(x))
				.ToArray();
		}


		public static IEnumerable<DateTime> GetDays(
			DateOnly start,
			DateOnly end)
		{
			return GetDays(start.GetDateTime(), end.GetDateTime());
		}


		public static DateTime Max(
			DateTime value1,
			DateTime? value2)
		{
			if (value2 == null)
				return value1;
			return (value1 > value2) ? value1 : value2.Value;
		}


		public static DateTime Max(
			DateOnly value1,
			DateOnly? value2)
		{
			return Max(value1.GetDateTime(), value2?.GetDateTime());
		}


		public static DateTime Min(
			DateTime value1,
			DateTime? value2)
		{
			if (value2 == null)
				return value1;
			return (value1 < value2) ? value1 : value2.Value;
		}


		public static DateTime Min(
			DateOnly value1,
			DateOnly? value2)
		{
			return Min(value1.GetDateTime(), value2?.GetDateTime());
		}

	}

}
