namespace Ans.Net8.Common
{

	public class AttributesBuilder
	{

		/* ctors */


		public AttributesBuilder()
		{
		}


		public AttributesBuilder(
			string serialization)
			: this()
		{
			Append(serialization);
		}


		/* readonly properties */


		public int Count
			=> Items.Count;

		public Dictionary<string, string> Items { get; } = [];


		/* functions */


		private string _join;
		public override string ToString()
		{
			return _join ??= Items.MakeFromCollection(
				x => $"{x.Key}=\"{x.Value}\"", null, null, " ");
		}


		public string GetJoin()
		{
			_join = null;
			return ToString();
		}


		public bool IsExists(
			string name)
		{
			return Items.ContainsKey(name);
		}


		/* methods */


		public void Append(
			string serialization)
		{
			const string _MASK1 = "###MASK1###";
			const string _MASK2 = "###MASK2###";
			if (!string.IsNullOrEmpty(serialization))
			{
				var s1 = serialization
					.Replace("=\"", _MASK1)
					.Replace("\" ", _MASK2);
				foreach (var item1 in s1.Split(_MASK2))
				{
					var a1 = item1.SplitFix(_MASK1, 2);
					Append(a1[0], a1[1]);
				}
			}
		}


		public void Append(
			string name,
			string value)
		{
			Items[name] = value ?? name;
		}


		public void Append(
			string name,
			int value,
			int nullValue = 0)
		{
			if (value != nullValue)
				Items[name] = value.ToString();
		}


		public void AppendIf(
			bool check,
			string name,
			string value)
		{
			if (check)
				Append(name, value);
		}


		public void Remove(
			string name)
		{
			Items.Remove(name);
		}


		public void Clear()
		{
			Items.Clear();
		}

	}

}
