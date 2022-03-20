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

        [HttpPost]
        public async Task<ActionResult<Person>> CreateNewPerson(Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _repo.Create(person);
                return CreatedAtAction(nameof(ReadPerson), new { id = createdPerson.PersonID }, createdPerson);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Couldn't add a new person to the database.....");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllProduct()
        {
            try
            {
                return Ok(await _repo.ReadAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data from database.....");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> ReadPerson(int id)
        {
            try
            {
                var result = await _repo.ReadSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to retrieve single person from database.....");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person person)
        {
            try
            {
                if (id != person.PersonID)
                {
                    return BadRequest("Product ID Doesn't Exist.....");
                }
                var updatedPerson = await _repo.ReadSingle(id);
                if (updatedPerson == null)
                {
                    return NotFound($"Person with ID {id} Not Found........");
                }
                return await _repo.Update(updatedPerson);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to update person to database.....");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            try
            {
                var deletePerson = await _repo.ReadSingle(id);
                if (deletePerson == null)
                {
                    return NotFound($"Person with ID {id} Not Found..........");
                }
                return await _repo.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Couldn't delete person from database.....");
            }
        }
    }
}
