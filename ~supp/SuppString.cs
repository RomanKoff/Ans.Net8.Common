using System.Text;

namespace Ans.Net8.Common
{

	public static class SuppString
	{

		/*
		 * string Default(string source, string defaultValue);

         * string Convert_WINDOWS1251_UTF8(string source);
         * string Convert_KOI8R_UTF8(string source);
         * string Convert_CP866_UTF8(string source);
         * string Convert_ISO88591_UTF8(string source);
         * string Join(string templateResult, string templateItem, string itemsSeparator, params string[] data);
         * string Join(string templateResult, string templateItem, string itemsSeparator, string data, string dataSeparator);
         * string Join(string itemsSeparator, params string[] data);
         * KeyValuePair<string, string> GetPair(string definition, string separator);
         * KeyValuePair<string, string> GetPair(string definition);
		 */


		/*
		 * Support win1251 and koi8r:
		 * Using System.Text.Encoding.CodePages 
		 * Program.cs -> Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		 * https://ru.stackoverflow.com/questions/1387144/%D0%BF%D0%B5%D1%80%D0%B5%D0%B2%D0%BE%D0%B4-%D0%B8%D0%B7-koi8-r-c
		 */


		public static string Default(
			string source,
			string defaultValue)
			=> (string.IsNullOrEmpty(source))
				? defaultValue : source;


		public static string Convert_WINDOWS1251_UTF8(
			string source)
		{
			return _Consts.ENCODING_UTF8.GetString(
				_Consts.ENCODING_WINDOWS1251.GetBytes(source));
		}


		public static string Convert_KOI8R_UTF8(
			string source)
		{
			return _Consts.ENCODING_UTF8.GetString(
				_Consts.ENCODING_KOI8R.GetBytes(source));
		}


		public static string Convert_CP866_UTF8(
			string source)
		{
			return _Consts.ENCODING_UTF8.GetString(
				_Consts.ENCODING_CP866.GetBytes(source));
		}


		public static string Convert_ISO88591_UTF8(
			string source)
		{
			return _Consts.ENCODING_UTF8.GetString(
				_Consts.ENCODING_ISO88591.GetBytes(source));
		}


		public static string Join(
			string resultTemplate,
			string itemTemplate,
			string itemsSeparator,
			params string[] data)
		{
			var sb1 = new StringBuilder();
			bool f1 = true;
			bool hasTemplateResult1 = !string.IsNullOrEmpty(resultTemplate);
			bool hasTemplateItem1 = !string.IsNullOrEmpty(itemTemplate);
			foreach (var s1 in data)
				if (!string.IsNullOrEmpty(s1))
				{
					if (f1)
						f1 = false;
					else
						sb1.Append(itemsSeparator);
					sb1.Append(hasTemplateItem1
						? string.Format(itemTemplate, s1) : s1);
				}
			var s2 = sb1.ToString();
			if (string.IsNullOrEmpty(s2))
				return string.Empty;
			return hasTemplateResult1
				? string.Format(resultTemplate, s2) : s2;
		}


		public static string Join(
			string templateResult,
			string templateItem,
			string itemsSeparator,
			string data,
			string dataSeparator)
		{
			return Join(
				templateResult, templateItem, itemsSeparator,
				data.Split(dataSeparator));
		}


		public static string Join(
			string itemsSeparator,
			params string[] data)
		{
			return Join(
				null, null, itemsSeparator, data);
		}


		public static KeyValuePair<string, string> GetPair(
			string definition,
			string separator)
		{
			int i1 = definition.IndexOf(separator);
			if (i1 > 0)
				return new KeyValuePair<string, string>(
					definition[..i1], definition[(i1 + separator.Length)..]);
			return new KeyValuePair<string, string>(
				definition, definition);
		}


		public static KeyValuePair<string, string> GetPair(
			string definition)
		{
			return GetPair(definition, "=");
		}

	}

}
