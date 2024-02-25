using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace RatServer.Core.Caching
{
    public class CacheService : ICacheService
    {

        private readonly ILogger logger;
        private readonly IMemoryCache _memoryCache;
        private static readonly CancellationTokenSource _resetCacheToken = new();
        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks = new();

        public CacheService(IMemoryCache memoryCache, ILogger<CacheService> logger)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            this.logger = logger;
        }
        public T Get<T>(object key)
        {
            return _memoryCache.TryGetValue(key, out T result) ? result : default;
        }
        public T Set<T>(object key, T result, int seconds = 86400)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.Normal);
            _ = options.AddExpirationToken(new CancellationChangeToken(_resetCacheToken.Token));
            _ = options.SetAbsoluteExpiration(TimeSpan.FromSeconds(seconds));
            _ = _memoryCache.Set(key, result, options);
            return result;
        }
        public T GetOrAdd<T>(string cacheKey, Func<T> createItem)
        {
            return _memoryCache.GetOrCreate(cacheKey, entry => createItem());
        }
        public async Task<T> GetOrAdd<T>(object key, Func<Task<T>> createItem, int seconds = 86400)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.Normal);
            _ = options.AddExpirationToken(new CancellationChangeToken(_resetCacheToken.Token));
            _ = options.SetAbsoluteExpiration(TimeSpan.FromSeconds(seconds));

            if (!_memoryCache.TryGetValue(key, out T result))// Look for cache key.
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();
                try
                {
                    if (!_memoryCache.TryGetValue(key, out result))
                    {
                        // Key not in cache, so get data.
                        result = await createItem();
                        _ = _memoryCache.Set(key, result, options);
                    }
                }
                catch (System.Exception ex)
                {
                    logger.LogError("CacheService error occurred {0},{1}", ex.Message, ex.StackTrace?.ToString());
                    throw;
                }
                finally
                {
                    _ = mylock.Release();
                }
            }
            return result;
        }
        public bool Contains<T>(object key)
        {
            return _memoryCache.TryGetValue(key, out T _);
        }
    }
}