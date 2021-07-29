using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Redis.Service;

namespace WebApplication1.Redis.Intercae
{
    public interface IRedis
    {
        Response Set(string key);
    }
}
