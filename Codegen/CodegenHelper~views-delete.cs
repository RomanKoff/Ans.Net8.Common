﻿using Ans.Net8.Common.Codegen.Items;
using System.Text;

namespace Ans.Net8.Common.Codegen
{

	public partial class CodegenHelper
	{

		/* ==================================================================== */
		private static string _getViewDelete(
			 TableItem table)
		{
			var sb1 = new StringBuilder();
			sb1.Append(_getRazorAttention());
			sb1.Append(@$"");
			return sb1.ToString();
		}
		/* ==================================================================== */

	}

}
