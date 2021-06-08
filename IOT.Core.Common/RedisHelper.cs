using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace OA.Core.Common
{
    public class RedisHelper<T>
    {
        public void Set(string key, List<T> ls)
        {
            using (IRedisClient client = new RedisClient("127.0.0.1", 6379)) 
            {
                client.Set<List<T>>(key, ls);
            }
        }
        public bool Exe(string key)
        {
            using (IRedisClient client = new RedisClient("127.0.0.1", 6379))
            {
                var result = client.ContainsKey(key);
                return result;
            }
        }
        public List<T> Get(string key)
        {
            using (IRedisClient client = new RedisClient("127.0.0.1", 6379))
            {
                var result = client.Get<List<T>>(key);
                return result;
            }
        }
    }
}
