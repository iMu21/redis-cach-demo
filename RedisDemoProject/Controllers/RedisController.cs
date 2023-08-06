using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisDemoProject.Interfaces;
using RedisDemoProject.Models;

namespace RedisDemoProject.Controllers
{
    [Route("api/redis")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IRedisCacheService _redisCacheService;

        public RedisController(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] GetCacheModel request)
        {
            var cacheString = await _redisCacheService.Get(request.Key);

            return cacheString == null ? StatusCode(StatusCodes.Status404NotFound) :
                StatusCode(StatusCodes.Status302Found, cacheString);
        }

        [HttpPost]
        [Route("set")]
        public async Task<IActionResult> Set([FromBody] SetCacheModel request)
        {
            return await _redisCacheService.Set(request.Key, request.Value) ? StatusCode(StatusCodes.Status201Created) :
                StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
