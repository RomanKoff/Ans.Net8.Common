using System.Reflection;

namespace Ans.Net8.Common
{

	public static partial class SuppApp
	{

		/* readonly properties */


		public static string CurrentPath
			=> Environment.CurrentDirectory;


		private static string _projectPath = null;
		public static string ProjectPath
			=> _projectPath ??= Directory.GetParent(Environment.CurrentDirectory)
				.Parent.Parent.FullName;


		private static string _solutionPath = null;
		public static string SolutionPath
			=> _solutionPath ??= Directory.GetParent(Environment.CurrentDirectory)
				.Parent.Parent.Parent.FullName;


		private static string _solutionNamespace = null;
		public static string SolutionNamespace
			=> _solutionNamespace ??= SolutionPath.Split('/', '\\').Last();


		/* functions */


		public static string GetName()
		{
			return Assembly.GetCallingAssembly()
				.GetName().Name;
		}


		public static string GetVersion()
		{
			var s1 = Assembly.GetCallingAssembly()
				.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
					.InformationalVersion.Split('+');
			return $"{s1[0]}";
		}


		public static string GetDescription()
		{
			return Assembly.GetCallingAssembly()
				.GetCustomAttribute<AssemblyDescriptionAttribute>()?
					.Description;
		}

	}

}
