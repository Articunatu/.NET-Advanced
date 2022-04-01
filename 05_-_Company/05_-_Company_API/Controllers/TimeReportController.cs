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
    public class TimeReportController : ControllerBase
    {
        private ICompany<TimeReport> _iTimeReport;

        public TimeReportController(ICompany<TimeReport> iTimeReport)
        {
            _iTimeReport = iTimeReport;
        }

        [HttpPost]
        public async Task<ActionResult<TimeReport>> CreateTimeReport(TimeReport newTimeReport)
        {
            try
            {
                if (newTimeReport == null)
                {
                    return BadRequest();
                }
                return await _iTimeReport.Create(newTimeReport);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to create new project to database.....");
            }
        }

        [HttpGet("e{id}")]
        public async Task<ActionResult<TimeReport>> ReadTimeReport(int id)
        {
            try
            {
                var readTimeReport = await _iTimeReport.Read(id);
                if (readTimeReport == null)
                {
                    return NotFound();
                }
                return readTimeReport;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to retrieve the chosen project from database.....");
            }
        }

        [HttpGet]
        public async Task<ActionResult<TimeReport>> ReadAllTimeReports()
        {
            try
            {
                return Ok(await _iTimeReport.ReadAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve projects from database.....");
            }
        }

        [HttpPut("e{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport(int id, TimeReport uptTimeReport)
        {
            try
            {
                if (id != uptTimeReport.ProjectID)
                {
                    return BadRequest("Project ID Doesn't Exist.....");
                }
                if (uptTimeReport == null)
                {
                    return NotFound($"Project with ID {id} Not Found........");
                }
                return await _iTimeReport.Update(uptTimeReport);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to update project to database.....");
            }
        }

        [HttpDelete("e{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                var delTimeReport = await _iTimeReport.Read(id);
                if (delTimeReport == null)
                {
                    return NotFound($"Project with ID {id} Not Found..........");
                }
                return await _iTimeReport.Delete(delTimeReport);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to delete project from database.....");
            }
        }
    }
}