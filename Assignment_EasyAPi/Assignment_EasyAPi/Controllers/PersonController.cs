using Assignment_EasyAPi.Model;
using Assignment_EasyAPi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_EasyAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IRepository<Person> _repo;

        public PersonController(IRepository<Person> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Person person)
        {
            var created = await _repo.Create(person);
            return CreatedAtAction(nameof(Read), new { id = created.ID }, created);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
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
        public async Task<ActionResult<Person>> Read(int id)
        {
            var result = await _repo.Read(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> Update(int id, Person person)
        {
            try
            {
                if (id != person.ID)
                {
                    return BadRequest("Product ID Doesn't Exist.....");
                }
                var updated = await _repo.Read(id);
                if (updated == null)
                {
                    return NotFound($"Product with ID {id} Not Found........");
                }
                return await _repo.Update(updated, id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to update product to database.....");
            }
        }

            [HttpDelete("{id}")]
            public async Task<ActionResult<Person>> Delete(int id)
            {
                var deleted = await _repo.Read(id);
                if (deleted != null)
                {
                    await _repo.Delete(deleted);
                    return deleted;
                }
                return NotFound();
            }
        }
    }
