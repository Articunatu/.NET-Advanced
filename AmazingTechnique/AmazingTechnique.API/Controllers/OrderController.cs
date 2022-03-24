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

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order newOrder)
        {
            try
            {
                if (newOrder == null)
                {
                    return BadRequest();
                }
                var created = await _amazingTechnique.Create(newOrder);
                return CreatedAtAction(nameof(ReadSingle), new { id = created.OrderID }, created);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            var updated = await _amazingTechnique.Update(order);
            if (updated == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No order to update....");
            }
            return updated;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var deleted = await _amazingTechnique.ReadSingle(id);
            if (deleted == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No order to delete....");
            }           
            return await _amazingTechnique.Delete(deleted.OrderID);
        }
    }
}
