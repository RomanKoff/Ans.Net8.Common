using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Ans.Net8.Common
{

	public class WebApiCachedHelper<T>
		: IWebApiHelper<T>
	{

		private readonly WebApiHelper<T> _webApi;
		private readonly IMemoryCache _memoryCache;


		/* ctor */


		public WebApiCachedHelper(
			HttpClient httpClient,
			IMemoryCache cache,
			string baseUrl,
			string cacheKey,
			MemoryCacheEntryOptions cacheOptions,
			JsonSerializerOptions jsonOptions)
		{
			_webApi = new(httpClient, baseUrl, jsonOptions);
			_memoryCache = cache;
			CacheKey = cacheKey;
			CacheOptions = cacheOptions;
		}


		/* readonly properties */


		public string CacheKey { get; }


		public string BaseUrl
			=> _webApi.BaseUrl;


		public JsonSerializerOptions JsonOptions
			=> _webApi.JsonOptions;


		public ParamsBuilder Params
			=> _webApi.Params;


		public MemoryCacheEntryOptions CacheOptions { get; }


		/* functions */


		public WebApiResult<T> SendQuery(
			string queryString)
		{
			if (!_memoryCache.TryGetValue(CacheKey, out WebApiResult<T> value1))
			{
				value1 = _webApi.SendQuery(queryString);
				_memoryCache.Set(
					CacheKey, value1, CacheOptions ?? _Consts.DEFAULT_CACHE_OPTIONS);
			}
			return value1;
		}


		public WebApiResult<T> SendQuery()
		{
			return SendQuery(Params.ToString());
		}


		/* methods */


		public void CacheClear()
		{
			_memoryCache.Remove(CacheKey);
		}

	}

}
