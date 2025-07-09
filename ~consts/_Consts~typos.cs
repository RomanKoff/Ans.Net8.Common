using System.Text;
using System.Web;

namespace Ans.Net8.Common
{

	public static partial class _Consts
	{

		public static readonly string TYPOGRAF_RU_WEBSERVICE_CONFIG
			= HttpUtility.UrlEncode(
				$@"<?xml version=""1.0"" encoding=""utf-8"" ?><preferences></preferences>",
				Encoding.UTF8);

		/*
		 * https://typograf.ru/webservice/about/
		 * 
		<?xml version="1.0" encoding="utf-8" ?>
		<preferences>
			<!-- Теги -->
			<tags delete="0">1</tags>
			<!-- Абзацы -->
			<paragraph insert="1">
				<start><![CDATA[<p>]]></start>
				<end><![CDATA[</p>]]></end>
			</paragraph>
			<!-- Переводы строк -->
			<newline insert="1"><![CDATA[<br />]]></newline>
			<!-- Переводы строк <p>&nbsp;</p> -->
			<cmsNewLine valid="0" />
			<!-- DOS текст -->
			<dos-text delete="0" />
			<!-- Неразрывные конструкции -->
			<nowraped insert="1" nonbsp="0" length="0">
				<start><![CDATA[<nobr>]]></start>
				<end><![CDATA[</nobr>]]></end>
			</nowraped>
			<!-- Висячая пунктуация -->
			<hanging-punct insert="0" />
			<!-- Удалять висячие слова -->
			<hanging-line delete="0" />
			<!-- Символ минус -->
			<minus-sign><![CDATA[&ndash;]]></minus-sign>
			<!-- Переносы -->
			<hyphen insert="0" length="0" />
			<!-- Акронимы -->
			<acronym insert="1"></acronym>
			<!-- Вывод символов 0 - буквами 1 - числами -->
			<symbols type="0" />
			<!-- Параметры ссылок -->
			<link target="" class="" />
		</preferences>
		*/

	}

}
