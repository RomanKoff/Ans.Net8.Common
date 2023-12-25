using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Text.Json;

namespace Ans.Net8.Common
{

	public class WebApiCachedHelper<T>(
		HttpClient httpClient,
		IMemoryCache cache,
		string cacheKey,
		MemoryCacheEntryOptions cacheOptions,
		string baseUrl,
		JsonSerializerOptions jsonOptions)
		: IWebApiHelper<T>
	{

		private readonly WebApiHelper<T> _webApi = new(httpClient, baseUrl, jsonOptions);
		private readonly IMemoryCache _memoryCache = cache;


		public WebApiCachedHelper(
			HttpClient httpClient,
			IMemoryCache cache,
			string cacheKey,
			MemoryCacheEntryOptions cacheOptions,
			string baseUrl,
			bool propertyNameCaseInsensitive = false)
			: this(httpClient, cache, cacheKey,
				  cacheOptions,
				  baseUrl, propertyNameCaseInsensitive
					? new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
					: null)
		{
		}


		public WebApiCachedHelper(
			HttpClient httpClient,
			IMemoryCache cache,
			string cacheKey,
			int slidingExpirationSeconds,
			int absoluteExpirationRelativeToNowSeconds,
			string baseUrl,
			JsonSerializerOptions jsonOptions)
			: this(httpClient, cache, cacheKey,
				  new MemoryCacheEntryOptions(),
				  baseUrl, jsonOptions)
		{
			if (slidingExpirationSeconds > 0)
				CacheOptions.SlidingExpiration = TimeSpan.FromSeconds(
					slidingExpirationSeconds);
			if (absoluteExpirationRelativeToNowSeconds > 0)
				CacheOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(
					absoluteExpirationRelativeToNowSeconds);
		}


		public WebApiCachedHelper(
			HttpClient httpClient,
			IMemoryCache cache,
			string cacheKey,
			int slidingExpirationSeconds,
			int absoluteExpirationRelativeToNowSeconds,
			string baseUrl,
			bool propertyNameCaseInsensitive = false)
			: this(httpClient, cache, cacheKey,
				  slidingExpirationSeconds, absoluteExpirationRelativeToNowSeconds,
				  baseUrl, propertyNameCaseInsensitive
					? new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
					: null)
		{
		}


		/* properties */


		public string CacheKey { get; set; } = cacheKey;
		public MemoryCacheEntryOptions CacheOptions { get; set; } = cacheOptions;

		public string BaseUrl
		{
			get => _webApi.BaseUrl;
			set => _webApi.BaseUrl = value;
		}

		public JsonSerializerOptions JsonOptions
		{
			get => _webApi.JsonOptions;
			set => _webApi.JsonOptions = value;
		}

		public ParamsBuilder Params
		{
			get => _webApi.Params;
			set => _webApi.Params = value;
		}


		/* functions */


		public WebApiResult<T> SendQuery(
			string queryString)
		{
			if (!_memoryCache.TryGetValue(CacheKey, out WebApiResult<T> value1))
			{
				value1 = _webApi.SendQuery(queryString);
				_memoryCache.Set(CacheKey, value1, CacheOptions);
				Debug.WriteLine($"[Ans.Net8.Common.WebApiCachedHelper] Set memory cache {CacheKey}.");
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
