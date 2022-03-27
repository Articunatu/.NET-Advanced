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
    public class WebLinkController : ControllerBase
    {
        private IRepository<Weblink> _repo3;

        public WebLinkController(IRepository<Weblink> repo3)
        {
            _repo3 = repo3;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Weblink>> ReadWebsite(int id)
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

        [HttpGet("p{id}")]
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

        [HttpPost("p{pId}/i{iId}")]
        public async Task<ActionResult<Weblink>> ConnectPersonToWeblink(Weblink weblink, int pId, int iId)
        {
            //try
            //{
            if (weblink == null)
            {
                BadRequest();
            }
            //var ConnectedWeblink = await _repo3.ConnectToPerson(weblink, pId, iId);
            //return CreatedAtAction(nameof(ReadWebsite),
            //    new Weblink
            //    {
            //        WebID = ConnectedWeblink.WebID
            //    }, ConnectedWeblink);
            var connectedWeblink = await _repo3.ConnectToPerson(weblink, pId, iId);
            return Created("", connectedWeblink);
            //}
            //catch (Exception)
            //{

            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error to add weblink to a person");
            //}

        }
    }
}