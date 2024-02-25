using System;
using System.Threading.Tasks;

namespace RatServer.Core.Caching
{
    public interface ICacheService
    {
        T Get<T>(object key);
        T Set<T>(object key, T result, int seconds = 86400);
        T GetOrAdd<T>(string cacheKey, Func<T> createItem);
        Task<T> GetOrAdd<T>(object key, Func<Task<T>> createItem, int seconds);
        bool Contains<T>(object key);
    }
}