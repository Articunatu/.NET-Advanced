using AmazingTechnique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTechnique.API.Model
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ReadCustomers();
        Customer ReadSingleCustomer(int id);

        IEnumerable<Customer> Search(string name);
    }
}
