namespace Ans.Net8.Common
{

	public static partial class _e
	{

		/*
         * IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo directoryInfo, params string[] extensions);
         * IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo directoryInfo, string extensions);
         */


		public static IEnumerable<FileInfo> GetFilesByExtensions(
			this DirectoryInfo directoryInfo,
			params string[] extensions)
		{
			ArgumentNullException.ThrowIfNull(extensions);
			var files1 = directoryInfo.EnumerateFiles();
			return files1.Where(x => extensions.Contains(x.Extension));
		}


		public static IEnumerable<FileInfo> GetFilesByExtensions(
			this DirectoryInfo directoryInfo,
			string extensions)
		{
			return GetFilesByExtensions(
				directoryInfo,
				extensions.Split([';', ',']));
		}

	}

}
