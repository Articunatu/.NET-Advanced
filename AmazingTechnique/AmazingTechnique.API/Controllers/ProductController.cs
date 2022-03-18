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

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
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
                                    "Error to retrieve single product from database.....");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateNewProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                var createdProduct = await _amazingTechnique.Create(product);
                return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.ProductID}, createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to create new product to database.....");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var deleteProduct = await _amazingTechnique.ReadSingle(id);
                if (deleteProduct == null)
                {
                    return NotFound($"Product with ID {id} Not Found..........");
                }
                return await _amazingTechnique.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to delete product from database.....");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            try
            {
                if (id != product.ProductID)
                {
                    return BadRequest("Product ID Doesn't Exist.....");
                }
                var updatedProduct = await _amazingTechnique.ReadSingle(id);
                if (updatedProduct == null)
                {
                    return NotFound($"Product with ID {id} Not Found........");
                }
                return await _amazingTechnique.Update(updatedProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to update product to database.....");
            }
        }
    }
}
