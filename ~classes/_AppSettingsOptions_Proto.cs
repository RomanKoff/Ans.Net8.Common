namespace Ans.Net8.Common
{

	public abstract class _AppSettingsOptions_Proto
	{
		public abstract void Test();

		public string SectionName { get; set; }

		public Exception GetExceptionParamRequired(
			string paramName)
		{
			return new Exception(
				$"[appsettings.json/{SectionName}/{paramName}] is required!");
		}
	}

}
