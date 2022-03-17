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
    public class ProductController : ControllerBase
    {
        private IAmazingTechnique<Product> _amazingTechnique;
        public ProductController(IAmazingTechnique<Product> amazingTechnique)
        {
            _amazingTechnique = amazingTechnique;
        }
        
        [HttpGet]
        public async Task<IActionResult> ReadAllProduct()
        {
            try
            {
                return Ok(await _amazingTechnique.ReadAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data from database.....");
            }
        }

    }
}
