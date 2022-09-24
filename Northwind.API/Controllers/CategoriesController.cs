using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entity.Concrete;

namespace Northwind.API.Controllers
{
    /// <summary>
    /// Category operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {        
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService; 
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        { 
            var result = _categoryService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        /// <summary>
        /// Get category by category id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("{categoryId}")]
        public IActionResult GetById(int categoryId)
        { 
            var result = _categoryService.GetById(x => x.CategoryId == categoryId);           
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category, (x => x.CategoryId == category.CategoryId));
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category, (x => x.CategoryId == category.CategoryId));
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
