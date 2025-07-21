using System.Text;

namespace Ans.Net8.Common
{

	public static class SuppTypograph
	{

		/* methods */


		public static void FixTextLine(
			StringBuilder sb)
		{
			sb.ReplaceSpecChars();
			sb.ReplaceRecursively("  ", " ", false);
			sb.Trim([' ']);
		}


		public static void FixTextBox(
			StringBuilder sb)
		{
			sb.Replace("\r", "");
			sb.ReplaceRecursively("  ", " ", false);
			sb.Replace(" \t", "\t");
			sb.Replace("\t ", "\t");
			sb.Replace(" \n", "\n");
			sb.Replace("\n ", "\n");
			sb.ReplaceRecursively("\n\n\n", "\n\n", false);
			sb.Trim(['\n']);
		}


		/* functions */


		private static readonly Dictionary<string, string> _DICT_HTML2TEXT = new()
		{
			{ "&", "&amp;" },
			{ ">", "&gt;" },
			{ "<", "&lt;" },
		};
		public static string GetHtml2Text(
			string value)
		{
			return value?.ReplaceFromDict(_DICT_HTML2TEXT);
		}

		private static readonly Dictionary<string, string> _DICT_TEXT2HTML = new()
		{
			{ "&amp;", "&" },
			{ "&gt;", ">" },
			{ "&lt;", "<" },
		};
		public static string GetText2Html(
			string value)
		{
			return value?.ReplaceFromDict(_DICT_TEXT2HTML);
		}


		private static readonly Dictionary<string, string> _DICT_TYPOGRAFFIX = new()
		{
			{ " г.", "&nbsp;г." },
			{ " .", "." },
			{ " ,", "," },
			{ " :", ":" },
			{ " ;", ";" },
			{ " - ", " —&nbsp;" },
			{ " -", "-" },
			{ "- ", "-" },
			{ "« ", "«" },
			{ " »", "»" },
			{ "” ", "”" },
			{ " “", "“" },
			{ "„ ", "„" },
			{ "( ", "(" },
			{ " )", ")" },
			{ "[ ", "[" },
			{ " ]", "]" },
			{  " …", "…" },
		};
		public static string GetTypografFix(
			string value)
		{
			var s1 = _Consts.G_REGEX_MULTYSPACE().Replace(value, " ");
			return s1?.ReplaceFromDict(_DICT_TYPOGRAFFIX);
		}


		public static string GetTypografElem(
			string value)
		{
			if (string.IsNullOrEmpty(value))
				return null;
			var value1 = GetTypografFix(value);
			if (string.IsNullOrEmpty(value1) || value1 == " ")
				return null;
			var f1 = value1.StartsWith(' ');
			var f2 = value1.Length > 1 && value1.EndsWith(' ');
			var a1 = value1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (a1.Length == 1)
				return a1[0];
			var sb1 = new StringBuilder();
			foreach (var w1 in a1.SkipLast(1))
			{
				sb1.Append(w1);
				sb1.Append(w1.Length < 4 ? "&nbsp;" : " ");
			}
			var s1 = sb1.ToString();
			var last1 = a1.Last();
			var s2 = (last1.Length < 4 && s1[^1] == ' ')
				? $"{s1[..^1]}&nbsp;{last1}"
				: $"{s1}{last1}";
			return $"{f1.Make(" ")}{s2}{f2.Make(" ")}";
		}


		public static string GetTypografMin(
			string value)
		{
			if (string.IsNullOrEmpty(value))
				return null;
			var helper1 = new TypografHelper(value);
			return helper1.Result;
		}


		public static string GetFixTextLine(
			string value)
		{
			if (string.IsNullOrEmpty(value))
				return string.Empty;
			var sb1 = new StringBuilder(value);
			FixTextLine(sb1);
			return sb1.ToString();
		}


		public static string GetFixTextBox(
			string value)
		{
			if (string.IsNullOrEmpty(value))
				return string.Empty;
			var sb1 = new StringBuilder(value);
			FixTextBox(sb1);
			return sb1.ToString();
		}

	}

}
