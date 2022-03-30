using _05___Company_API.Services;
using _05___Company_DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___Company_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ICompany<Employee> company;
        public EmployeeController()
        {

        }

        [HttpGet("week{week}/emp{eid}")]
        public void ReadHours(int week, int eid)
        {

        }
    }
}
