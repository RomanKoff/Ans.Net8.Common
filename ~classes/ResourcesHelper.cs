using Ans.Net8.Common.Resources;
using System.Resources;

namespace Ans.Net8.Common
{

	public class ResourcesHelper
	{

		/* ctor */


		public ResourcesHelper(
			params ResourceManager[] resources)
		{
			Resources = resources;
		}


		/* readonly properties */


		public ResourceManager[] Resources { get; }


		/* functions */


		public string GetString(
			string key)
		{
			if (key == null)
				return null;
			if (Resources == null)
				return key;
			foreach (var resource1 in Resources)
			{
				var s1 = resource1?.GetString(key);
				if (!string.IsNullOrEmpty(s1))
					return s1;
			}
			return null;
		}


		public CrudFaceHelper GetFaceHelper(
			string name)
		{
			var s1 = GetString(name)
				?? Faces.ResourceManager.GetString(name)
				?? name;
			return new CrudFaceHelper(name, s1);
		}

	}

}
