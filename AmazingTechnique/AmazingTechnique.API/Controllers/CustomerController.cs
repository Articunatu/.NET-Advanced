using AmazingTechnique.API.Model;
using AmazingTechnique.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTechnique.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepo;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }

        [HttpGet]
        public IActionResult ReadAllCustomers()
        {
            return Ok(_customerRepo.ReadCustomers());
        }

        [HttpGet("{id:int}")]
        public IActionResult ReadSingleCustomer(int id)
        {
            var readCustomer = _customerRepo.ReadSingleCustomer(id);
            if (readCustomer != null)
            {
                return Ok(readCustomer);
            }
            return NotFound($"Customer with id {id} Not Found");
        }

        [HttpGet("{search}")]
        public IActionResult Search(string name)
        {
            var searchCustomer = _customerRepo.Search(name);
            if (searchCustomer.Any())
            {
                return Ok(searchCustomer);
            }
            return NotFound($"Customer with name {name} Not Found");
        }
    }
}
