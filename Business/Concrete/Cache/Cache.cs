using Business.Abstract.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Cache
{
    public class Cache:ICache
    {
        private IDistributedCache _distributedCache;
        private IMemoryCache _memoryCache;
        public Cache(IDistributedCache cache, IMemoryCache memoryCache)
        {
            _distributedCache = cache;
            _memoryCache = memoryCache;
        }
        public void DCSetString(string key, string value)
        {
            _distributedCache.SetString(key, value);
        }
        public void DCSetList(string key)
        {
            var arrayNumber = new int[] { 1, 2, 3, 8 };
            var stringArray = System.Text.Json.JsonSerializer.Serialize(arrayNumber);
            _distributedCache.Set(key, System.Text.Encoding.UTF8.GetBytes(stringArray));
        }

        public string DCGetValue(string key)
        {
            return _distributedCache.GetString(key);
        }

        public void IMCSetString(string key, string value)
        {
            _memoryCache.Set(key, value);
        }

        public void IMCSetObject(string key, object value)
        {
            _memoryCache.Set(key, value);
        }

        public T IMCGetValue<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
    }
}
