using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace API.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductRepository repository;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            repository = new();
        }

        [HttpPost]
        [Route("starstore/product")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
               var  _createdProduct = repository.Create(product);

                return Ok(_createdProduct);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Unable to create the product {product.Title}.", exc);

                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
