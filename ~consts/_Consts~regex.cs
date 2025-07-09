using System.Text.RegularExpressions;

namespace Ans.Net8.Common
{

	public static partial class _Consts
	{

		public const string REGEX_NAME
			= @"^([a-z_][0-9a-z._-]+)$";

		public const string REGEX_VARNAME
			= @"^([a-zA-Z_][0-9a-zA-Z_]+)$";

		public const string REGEX_EMAIL
			= @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";


		[GeneratedRegex(@"(?<=</?)([^ >/]+)")]
		public static partial Regex G_REGEX_TAGS();

		[GeneratedRegex(@"[]^\\-]")]
		public static partial Regex G_REGEX_ENCODE();

		[GeneratedRegex(REGEX_NAME)]
		public static partial Regex G_REGEX_NAME();

		[GeneratedRegex(REGEX_VARNAME)]
		public static partial Regex G_REGEX_VARNAME();

		[GeneratedRegex(@"^(([a-zA-Z_][0-9a-zA-Z_-]+)/){0,}([a-zA-Z_][0-9a-zA-Z_-]+)$")]
		public static partial Regex G_REGEX_IPATH();

		[GeneratedRegex(@"^([a-z_][0-9a-z_-]+)$")]
		public static partial Regex G_REGEX_NAME_STRICT();

		[GeneratedRegex(@"^([a-z_][0-9a-z_]+)$")]
		public static partial Regex G_REGEX_VARNAME_STRICT();

		[GeneratedRegex(@"^(([a-z_][0-9a-z_-]+)/){0,}([a-z_][0-9a-z_-]+)$")]
		public static partial Regex G_REGEX_IPATH_STRICT();

		[GeneratedRegex(REGEX_EMAIL)]
		public static partial Regex G_REGEX_EMAIL();

		[GeneratedRegex(@"^(?("")(""[^""]+""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$")]
		public static partial Regex G_REGEX_EMAIL2();

		[GeneratedRegex(@"(https?://)[-_./:\?=&%#a-zA-Z0-9]+")]
		public static partial Regex G_REGEX_URL();

		[GeneratedRegex(@"\d")]
		public static partial Regex G_REGEX_ONLY_NUMBER();

		[GeneratedRegex(@"\D")]
		public static partial Regex G_REGEX_NOT_NUMBER();

		[GeneratedRegex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b")]
		public static partial Regex G_REGEX_IP4();

		[GeneratedRegex(@"^([0-9a-zA-Z `\'"":;,\.<>+=\~_\?\!\@#\$%\^\&\*\(\)\[\]\{\}/\\\|-]+)$")]
		public static partial Regex G_REGEX_PASSWORD();

		[GeneratedRegex(@"^[A-Za-zА-ЯЁа-яё-]{1,23}( [A-Za-zА-ЯЁа-яё-]{1,23})+$")]
		public static partial Regex G_REGEX_FIO_RU();

		[GeneratedRegex(@"[\s]{2,}", RegexOptions.None)]
		public static partial Regex G_REGEX_MULTYSPACE();

		[GeneratedRegex(@"([0..9.,_-]{1,3})", RegexOptions.None)]
		public static partial Regex G_REGEX_SMALLNUMBER();

	}

}
