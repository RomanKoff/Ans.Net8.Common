using System.Collections.Generic;

namespace Ans.Net8.Common
{

	public class DictString
		: Dict<string>,
		IDictionary<string, string>
	{
		public DictString()
			: base()
		{
		}

		public DictString(
			string serialization)
			: base(serialization)
		{
		}

		public override string ToValue(
			string value)
		{
			return value;
		}


		public string GetValueOrKey(
			string key)
		{
			return TryGetValue(key, out var value1)
				? ToValue(value1) : key;
		}
	}



	public abstract class Dict<T>
		: Dictionary<string, T>,
		IDictionary<string, T>
	{

		/* ctors */


		public Dict()
		{
		}

		public Dict(
			string serialization)
			: this()
		{
			Clear();
			foreach (var item1 in serialization.Split(';'))
				Add(item1);
		}


		public abstract T ToValue(string value);


		/* methods */


		public void Add(
			string serialization)
		{
			var a1 = serialization.Split("=");
			Add(a1[0], ToValue(a1[1]));
		}

	}

}
