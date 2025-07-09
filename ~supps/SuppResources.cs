﻿using Ans.Net8.Common.Resources;
using System.Resources;

namespace Ans.Net8.Common
{

	public static class SuppResources
	{

		/* functions */


		public static ResourceManager[] GetFormResourceManagers(
			params ResourceManager[] resources)
		{
			var a1 = new ResourceManager[] { Faces.ResourceManager };
			return [.. resources, .. a1];
		}
	}

}
