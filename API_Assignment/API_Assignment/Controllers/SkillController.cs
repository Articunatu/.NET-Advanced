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
    public class SkillController : ControllerBase
    {
        IService<Skill> _repo;
        public SkillController(IService<Skill> repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> ReadSingleSkill(int id)
        {
            var readPerson = _repo.ReadSingle(id);
            return Ok(await readPerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Skill>> UpdateSkill(int id, Skill person)
        {
            try
            {
                if (id != person.SkillID)
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
        public async Task<ActionResult<Skill>> ReadAllSkills()
        {
            return Ok(await _repo.ReadAll());
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> CreateSkill(Skill person)
        {
            return await _repo.Create(person);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Skill>> DeleteSkill(int id)
        {
            return await _repo.Delete(id);
        }

        [HttpGet("p{id}")]
        public async Task<ActionResult<Object>> ReadConnectedEntities(int id)
        {
            var foundSkills = _repo.ReadConnectedEntities(id);
            return Ok(await foundSkills);
        }
    }
}
