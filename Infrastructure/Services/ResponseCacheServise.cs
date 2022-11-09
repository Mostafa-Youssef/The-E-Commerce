using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Services
{
    public class ResponseCacheServise : IResponseCacheService
    {
        private readonly IDatabase _database;
        public ResponseCacheServise(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
        {
            if(response == null) return;

            var options = new JsonSerializerOptions 
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var serializedResponse = JsonSerializer.Serialize(response, options);

            await _database.StringSetAsync(cacheKey, serializedResponse, timeToLive);
        }

        public async Task<string> GetCacheResposeAsync(string cacheKey)
        {
            var cachedRepsonse = await _database.StringGetAsync(cacheKey);

            if(cachedRepsonse.IsNullOrEmpty) return null;

            return cachedRepsonse;
        }
    }
}