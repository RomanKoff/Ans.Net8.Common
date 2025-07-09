namespace Ans.Net8.Common
{

	public static partial class __e_collections
	{

		/// <example>
		/// foreach (var (item1, i1) in data1.WithIndex())
		/// </example>
		public static IEnumerable<(T item, int index)> WithIndex<T>(
			this IEnumerable<T> source)
		{
			return source.Select((item, index) => (item, index));
		}


		public static IEnumerable<T> GetRelevantOrUpdated<T>(
			this IEnumerable<T> current,
			IEnumerable<T> newest,
			Func<T, T, bool> compare)
		{
			return
				from c1 in current
				from n1 in newest
				where compare(c1, n1)
				select n1;
		}


		public static IEnumerable<T> GetAdded<T>(
			this IEnumerable<T> current,
			IEnumerable<T> newest,
			Func<T, T, bool> compare)
		{
			return
				from n1 in newest
				where !current.Any(c1 => compare(c1, n1))
				select n1;
		}


		public static IEnumerable<T> GetRemoved<T>(
			this IEnumerable<T> current,
			IEnumerable<T> newest,
			Func<T, T, bool> compare)
		{
			return
				from c1 in current
				where !newest.Any(n1 => compare(c1, n1))
				select c1;
		}


		public static T[] GetAdd<T>(
			this T[] items,
			T item)
		{
			var a1 = items.ToList();
			a1.Add(item);
			return [.. a1];
		}


		public static T[] GetInsert<T>(
			this T[] items,
			int index,
			T item)
		{
			var a1 = items.ToList();
			a1.Insert(index, item);
			return [.. a1];
		}


		public static T[] GetRemoveAt<T>(
			this T[] items,
			int index)
		{
			var a1 = items.ToList();
			a1.RemoveAt(index);
			return [.. a1];
		}


		public static IEnumerable<string> GetTrim(
			this IEnumerable<string> source)
		{
			return source.Select(
				x => x.Trim());
		}


		public static IEnumerable<string> GetRemoveEmpty(
			this IEnumerable<string> source)
		{
			return source.Where(
				x => !string.IsNullOrEmpty(x));
		}

	}

}
