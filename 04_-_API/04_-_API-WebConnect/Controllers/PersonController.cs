using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _04___API.Repository;
using _04___API.Models;

namespace _04___API_WebConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IRepository<Person> _repo;
        public PersonController(IRepository<Person> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllPersons()
        {
            try
            {
                return Ok(await _repo.ReadAll(null));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve persons from database.....");
            }
        }
    }
}
