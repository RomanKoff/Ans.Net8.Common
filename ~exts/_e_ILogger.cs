using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Ans.Net8.Common
{

	public static partial class _e_ILogger
	{

		/* functions */


		public static void LogInformation2(
			this ILogger logger,
			string message)
		{
			logger.LogInformation(message);
			Debug.WriteLine(message);
		}


		public static void LogDebug2(
			this ILogger logger,
			string message)
		{
			logger.LogDebug(message);
			Debug.WriteLine(message);
		}


		public static void LogError2(
			this ILogger logger,
			string message)
		{
			logger.LogError(message);
			Debug.WriteLine(message);
		}

	}

}
