using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsost
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache  = ServiceTool.ServiceProvider.GetService<IMemoryCache>(); 
        }
        public void Add(string key, object value, int durationMinute)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(durationMinute));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out var _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {


            dynamic cacheEntriesCollection = null;
            var cacheEntriesFieldCollectionDefinition = typeof(MemoryCache).GetField("_coherentState", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (cacheEntriesFieldCollectionDefinition != null)
            {
                //bu memeory cache state ini verir
                var coherentStateValueCollection = cacheEntriesFieldCollectionDefinition.GetValue(_memoryCache);

                // bu Entrileri getirir anacag hansi memeory cache den oldugunu bilmir
                var entriesCollectionValues = coherentStateValueCollection?.GetType()
                    .GetProperty(
                        "EntriesCollection",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                    );

                // In Memeory[Server(_memerycache)] de Entrileri entriesCollectionValues degerine menimsetdi
                cacheEntriesCollection = entriesCollectionValues.GetValue(coherentStateValueCollection);

            }


            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
            foreach (var cacheItem in cacheEntriesCollection)
            {
                var cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
