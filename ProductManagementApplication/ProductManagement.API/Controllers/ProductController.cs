using Microsoft.AspNetCore.Mvc;
using ProductManagement.BusinessLogic.Interfaces;
using ProductManagement.DataAccess.Entities;
using System.Net;

namespace ProductManagement.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController(
        ILogger<ProductController> _logger,
        IProductTypeService _productTypeService,
        IEntityService _entityService,
        IProductService _productService) : ControllerBase
    {


        /// <summary>
        /// Returns all product types
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="500">Server side error</response>
        [HttpGet]
        [Route("productTypes")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProductTypes()
        {
            try
            {
                IEnumerable<ProductType> productTypes = await _productTypeService.GetProductTypesAsync(); 
                return Ok(productTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Server side error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Returns a product type by its id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Server side error</response>
        [HttpGet]
        [Route("productType/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProductType(Guid id)
        {
            try
            {
                ProductType productType = await _productTypeService.GetProductTypeAsync(id);
                return Ok(productType);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError($"Product type with ID {id} not found.");
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Server side error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <response code="201">Created</response>
        /// <response code="500">Server side error</response>
        [HttpPost]
        [Route("product")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateNewProduct(ProductDto productDto)
        {
            try
            {
                var product = _entityService.CreateProduct(productDto);
                await _productService.AddNewProductAsync(product);
                return StatusCode(StatusCodes.Status201Created, product);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Server side error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Returns a list of all products
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="500">Server side error</response>
        [HttpGet]
        [Route("products")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            try
            {
                IEnumerable<Product> sortedProducts = await _productService.GetAllProductsAsync();
                return Ok(sortedProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Server side error occurred: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a product by product id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Server side error</response>
        [HttpDelete]
        [Route("product/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError($"Product type with ID {id} not found and therefore cannot be deleted.");
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Server side error occurred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
