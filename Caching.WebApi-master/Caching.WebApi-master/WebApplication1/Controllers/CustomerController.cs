using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Redis.Intercae;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        public readonly IRedis _redis;
        public CustomerController(IRedis redis)
        {
            _redis = redis;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersUsingRedisCache()
        {
            var resposne=_redis.Set("");
            return Ok(resposne);
        }
    }
}
