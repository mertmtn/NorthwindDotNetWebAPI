using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entity.Concrete;

namespace Northwind.API.Controllers
{
    /// <summary>
    /// Product controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    { 
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        /// <summary>
        /// Get product by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public IActionResult GetById(int productId)
        { 
            var result = _productService.GetById(x => x.ProductId == productId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product, (x => x.ProductId == product.ProductId));
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product, (x => x.ProductId == product.ProductId));
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
