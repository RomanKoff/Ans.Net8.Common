using System.Text;

namespace Ans.Net8.Common
{

	public abstract class _Dict_Proto<TKey, TValue>
		: Dictionary<TKey, TValue>,
		IDictionary<TKey, TValue>
	{

		private const string _MASK1 = "###MASK1###";


		/* abstracts */


		public abstract TKey StringToKey(string key);
		public abstract TValue StringToValue(string value);
		public abstract string KeyToString(TKey key);
		public abstract string ValueToString(TValue value);


		/* ctors */


		public _Dict_Proto()
		{
		}


		public _Dict_Proto(
			string serialization)
			: this()
		{
			Clear();
			var s1 = serialization.Replace("\\;", _MASK1);
			var a1 = s1.Split(';');
			foreach (var item1 in a1)
				Add(item1.Replace(_MASK1, ";"));
		}


		/* methods */


		public void Add(
			string serialization)
		{
			var s1 = serialization.Replace("\\=", _MASK1);
			var a1 = s1.Split('=');
			var key1 = a1[0].Replace(_MASK1, "=");
			var value1 = a1[1].Replace(_MASK1, "=");
			Add(StringToKey(key1), StringToValue(value1));
		}


		/* functions */


		public override string ToString()
		{
			var sb1 = new StringBuilder();
			foreach (var key1 in Keys)
			{
				var key2 = KeyToString(key1)
					.Replace("=", "\\=")
					.Replace(";", "\\;");
				var value2 = ValueToString(this[key1])
					.Replace("=", "\\=")
					.Replace(";", "\\;");
				sb1.Append($"{key2}={value2};");
			}
			return sb1.ToString()[..^1];
		}


		public string GetValueOrKey(
			TKey key)
		{
			return TryGetValue(key, out TValue value1)
				? ValueToString(value1) : KeyToString(key);
		}

	}

}
