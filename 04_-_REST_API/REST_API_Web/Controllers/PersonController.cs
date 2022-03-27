using _04___REST_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API_Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Web.Controllers
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
                return Ok(await _repo.ReadAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve persons from database.....");
            }
        }
    }
}
