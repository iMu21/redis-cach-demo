using RedisDemoProject.Interfaces;
using StackExchange.Redis;

namespace RedisDemoProject.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string?> Get(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();

            var res= await db.StringGetAsync(key);

            return res;
        }

        public async Task<bool> Set(string key, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();

            var res =  await db.StringSetAsync(key, value);

            return res;
        }
    }
}
