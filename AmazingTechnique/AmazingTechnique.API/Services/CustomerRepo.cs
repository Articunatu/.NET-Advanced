using AmazingTechnique.API.Model;
using AmazingTechnique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTechnique.API.Services
{
    public class CustomerRepo : ICustomerRepository
    {
        private AppDbContext _appDbContext;
        public CustomerRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Customer> ReadCustomers()
        {
            return _appDbContext.Customers;
        }

        public Customer ReadSingleCustomer(int id)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.CustomerID == id);
        }

        public IEnumerable<Customer> Search(string name)
        {
            IQueryable<Customer> quer = _appDbContext.Customers;
            if (!string.IsNullOrEmpty(name))
            {
                quer = quer.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
            }
            return quer.ToList();
        }
    }
}
