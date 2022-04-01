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
                                    "Error to create new time report to database.....");
            }
        }

        [HttpGet("tr{id}")]
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
                                    "Error to retrieve the chosen time report from database.....");
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
                    "Error to retrieve time reports from database.....");
            }
        }

        [HttpPut("tr{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport(int id, TimeReport uptTimeReport)
        {
            try
            {
                if (id != uptTimeReport.ProjectID)
                {
                    return BadRequest("Time Report ID Doesn't Exist.....");
                }
                if (uptTimeReport == null)
                {
                    return NotFound($"Time Report with ID {id} Not Found........");
                }
                return await _iTimeReport.Update(uptTimeReport);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to update time report to database.....");
            }
        }

        [HttpDelete("tr{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                var delTimeReport = await _iTimeReport.Read(id);
                if (delTimeReport == null)
                {
                    return NotFound($"Time Report with ID {id} Not Found..........");
                }
                return await _iTimeReport.Delete(delTimeReport);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to delete time Report from database.....");
            }
        }
    }
}