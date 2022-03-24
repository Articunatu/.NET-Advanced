using AmazingTechnique.API.Services;
using AmazingTechnique.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTechnique.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IAmazingTechnique<Order> _amazingTechnique;

        public OrderController(IAmazingTechnique<Order> amazingTechnique)
        {
            _amazingTechnique = amazingTechnique;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllOrders()
        {
            try
            {
                return Ok(await _amazingTechnique.ReadAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve orders from database.....");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> ReadSingle(int id)
        {
            try
            {
                var result = await _amazingTechnique.ReadSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrieve orders from database.....");
            }
            
        }
    }
}
