using StackExchange.Redis;
using System.Threading.Tasks;

namespace Shared.Redis
{
    public class RedisWrapper : IRedisWrapper
    {
        IDatabase db;
        public RedisWrapper()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            db = redis.GetDatabase();
        }

        public async Task<string> GetAsync(string key)
        {
            return await db.StringGetAsync(key).ConfigureAwait(false);
        }

        public async Task SaveAsync(string key, string body)
        {
            await db.StringSetAsync(key, body).ConfigureAwait(false);
        }
    }
}
