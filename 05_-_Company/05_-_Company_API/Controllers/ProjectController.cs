using _05___Company_API.Services;
using _05___Company_DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace _05___Company_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private ICompany<Project> _iproject;

        public ProjectController(ICompany<Project> iproject)
        {
            _iproject = iproject;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project newProject)
        {
            try
            {
                if (newProject == null)
                {
                    return BadRequest();
                }
                return await _iproject.Create(newProject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to create new project to database.....");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> ReadSingleProject(int id)
        {
            try
            {
                var readEmployee = await _iproject.Read(id);
                if (readEmployee == null)
                {
                    return NotFound();
                }
                return readEmployee;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to read the chosen project from database.....");
            }
        }

        [HttpGet]
        public async Task<ActionResult<Project>> ReadAllProjects()
        {
            try
            {
                return Ok(await _iproject.ReadAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to read all projects from database.....");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project uptProject)
        {
            try
            {
                if (id != uptProject.ProjectID)
                {
                    return BadRequest("Project ID Doesn't Exist.....");
                }
                if (uptProject == null)
                {
                    return NotFound($"Project with ID {id} Not Found........");
                }
                return await _iproject.Update(uptProject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to update project to database.....");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var delProject = await _iproject.Read(id);
                if (delProject == null)
                {
                    return NotFound($"Project with ID {id} Not Found..........");
                }
                return await _iproject.Delete(delProject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to delete project from database.....");
            }
        }
    }
}