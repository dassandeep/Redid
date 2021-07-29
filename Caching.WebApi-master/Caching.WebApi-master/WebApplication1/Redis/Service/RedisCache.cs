using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Interface;
using WebApplication1.Model;
using WebApplication1.Redis.Intercae;

namespace WebApplication1.Redis.Service
{
    public class RedisCache : IRedis
    {
        private readonly IDataReader1 _dataReader1;
        private readonly IDistributedCache _distributedCache;
        public RedisCache(IDataReader1 dataReader1, IDistributedCache distributedCache)
        {
            _dataReader1 = dataReader1;
            _distributedCache = distributedCache;
        }
        public Response Set(string query)
        {
            Response response = new Response();
            string serializedCustomerList;
            var customerList = new List<Customer>();
            var v = _dataReader1.GetList(""); 
            if(v!=null)
            {
                response.RedisKey = Guid.NewGuid().ToString();

                serializedCustomerList = JsonConvert.SerializeObject(customerList);
                var redisCustomerList = Encoding.UTF8.GetBytes(serializedCustomerList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                 _distributedCache.SetAsync(response.RedisKey, redisCustomerList, options);
                response.Error = "NoError";
            }
            return response;
        }
    }
    public class Response
    {
        public string Error { get; set; }
        public string RedisKey { get; set; }
    }
}
