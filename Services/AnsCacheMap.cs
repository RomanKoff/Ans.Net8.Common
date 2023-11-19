using Microsoft.Extensions.Caching.Memory;

namespace Ans.Net8.Common.Services
{

	public interface IAnsCacheMap
	{
		IDictionary<string, CacheInfo> Items { get; }
	}



	public class AnsCacheMap
		: IAnsCacheMap
	{
		public AnsCacheMap()
		{
			Items = new Dictionary<string, CacheInfo>();
		}

		public IDictionary<string, CacheInfo> Items { get; private set; }
	}



	public class CacheInfo
	{
		public MemoryCacheEntryOptions Options { get; set; }
	}

}
