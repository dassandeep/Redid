using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess.Interface;
using WebApplication1.Model;

namespace WebApplication1.DataAccess.Service
{
    public class DataReader : IDataReader1
    {
        public List<Customer> GetList(string key)
        {
            return this.GetCustomer();
        }
        public  List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, FirstName = "ggg" });
            customers.Add(new Customer { Id = 2, FirstName = "ggg2222" });
            return customers;
        }
    }
}
