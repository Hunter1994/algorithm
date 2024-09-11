using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DemoController : ControllerBase
    {
        private IMemoryCache _memoryCache;
        private IDistributedCache _distributedCache;
        private ObjectPool<RequestDto> _objectPool;

        public DemoController(IMemoryCache memoryCache,IDistributedCache distributedCache,ObjectPool<RequestDto> objectPool)
        {
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
            _objectPool = objectPool;
        }
        [HttpGet("get4")]
        public RequestDto Get4()
        {
            var data = _objectPool.Get();
            data.Name = "1";
            _objectPool.Return(data);
            return data;

        }
        [HttpGet("get5")]
        public RequestDto Get5()
        {
            var data = _objectPool.Get();
            return data;
        }

        [HttpGet]
        public string Get()
        {
            return _memoryCache.GetOrCreate<string>("key", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);
                entry.SetPriority(CacheItemPriority.NeverRemove);//在内存压力触发的清理过程中，不应删除缓存项。
                //内存失效回调方法（只有再次访问这个key的时候才会触发）
                entry.RegisterPostEvictionCallback((object key, object? value, EvictionReason reason, object? state) => {
                    Console.WriteLine(key);
                    Console.WriteLine(value);
                    Console.WriteLine(state);
                });
                return DateTime.Now.ToString();
            });
        }


        [HttpGet("get2")]
        public string Get2()
        {
           var resbyes= _distributedCache.Get("key");
            if (resbyes == null)
            {
                var data = DateTime.Now.ToString();
                _distributedCache.Set("key", Encoding.UTF8.GetBytes(data), new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5)
                });
                return data;
            }
            return Encoding.UTF8.GetString(resbyes);
        }

        [HttpGet("get3")]
        [ResponseCache(Duration =10,Location =ResponseCacheLocation.Client,NoStore =true)]
        public string Get3()
        {

            var data = DateTime.Now.ToString();

            return data;

        }

    }
}
