using API_Assignment.Models;
using API_Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IService<Person> _repo;
        public PersonController(IService<Person> repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> ReadSinglePerson(int id)
        {
            var readPerson = _repo.ReadSingle(id);
            return Ok(await readPerson);
        }

        [HttpGet("namn={name}")]
        public async Task<ActionResult<Person>> SearchPersonName(string name)
        {
            var searchedPersons = _repo.Search(name);
            return Ok(await searchedPersons);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person person)
        {
            try
            {
                if (id != person.PersonID)
                {
                    return BadRequest();
                }
                //var uptPerson = await _repo.ReadSingle(id);
                //if (person == null)
                //{
                //    return NotFound("No person updated:.....");
                //}
                return await _repo.Update(person);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to update person to database.....");
            }
        }

        [HttpGet]
        public async Task<ActionResult<Person>> ReadAllPersons()
        {
            return Ok(await _repo.ReadAll());
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            return await _repo.Create(person);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            return await _repo.Delete(id);
        }
    }
}
