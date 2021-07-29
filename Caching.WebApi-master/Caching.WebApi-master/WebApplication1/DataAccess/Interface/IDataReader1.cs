using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.DataAccess.Interface
{
    public interface IDataReader1
    {
        List<Customer> GetList(string key);
    }
}
