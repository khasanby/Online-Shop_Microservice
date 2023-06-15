using Catalog.API.Models;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public sealed class CatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository repository, ILogger<CatalogController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Returns all products.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDb>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDb>>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Returns product by id.
        /// </summary>
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProductDb), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDb>> GetProductByIdAsync(string id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Returns products by category.
        /// </summary>
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDb>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDb>>> GetProductsByCategoryAsync(string category)
        {
            var products = await _repository.GetProductsByCategoryAsync(category);
            return Ok(products);
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ProductDb), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDb>> CreateProductAsync([FromBody] ProductDb product)
        {
            await _repository.CreateProductAsync(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ProductDb), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDb product)
        {
            return Ok(await _repository.UpdateProductAsync(product));
        }

        /// <summary>
        /// Deletes a product by id.
        /// </summary>
        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ProductDb), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductByIdAsync(string id)
        {
            return Ok(await _repository.DeleteProductByIdAsync(id));
        }
    }
}