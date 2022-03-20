using _04___API.Models;
using _04___API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04___API_WebConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IRepository<Interest> _repo2;

        public InterestController(IRepository<Interest> repo2)
        {
            _repo2 = repo2;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadPersonsInterests(int id)
        {
            try
            {
                return Ok(await _repo2.ReadSingle(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve this person's interests from database.....");
            }
        }
    }
}
