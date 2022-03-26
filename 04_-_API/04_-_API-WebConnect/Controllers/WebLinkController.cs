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
    public class WebLinkController : ControllerBase
    {
        private IRepository<WebLink> _repo3;

        public WebLinkController(IRepository<WebLink> repo3)
        {
            _repo3 = repo3;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebLink>> ReadWebsite(int id)
        {
            try
            {
                var result = await _repo3.ReadSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadPersonsWeblinks(int id)
        {
            try
            {
                return Ok(await _repo3.SearchByPerson(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve this person's weblinks from database.....");
            }
        }

        [HttpPost("person{personID}interest{interestID}")]
        public async Task<ActionResult<WebLink>> ConnectPersonToWeblink(WebLink weblink, int pId, int iId)
        {
            try
            {
                if (weblink == null)
                {
                    BadRequest();
                }
                var ConnectedWeblink = await _repo3.ConnectToPerson(weblink, pId, iId);
                return CreatedAtAction(nameof(ReadWebsite), new { id = ConnectedWeblink.WebID }, ConnectedWeblink);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add data to database");
            }
        }
    }
}
