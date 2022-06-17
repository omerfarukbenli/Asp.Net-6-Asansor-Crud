using Elevator.Business.Abstract;
using Elevator.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elevator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult> GetCategories([FromQuery] string searchTerm)
        {
            return Ok(await _categoryService.GetCategories(searchTerm));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryId(int id)
        {
            return Ok(await _categoryService.GetCategoriesID(id));
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllCategory()
        {
            return Ok(await _categoryService.GetAllCategory());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDto)
        {
            return Ok(await _categoryService.Post(categoryDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto categoryDto)
        {
            return Ok(await _categoryService.Update(categoryDto, id));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            return Ok(await _categoryService.DeleteByIdAsync(id));

        }




        ///////

        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody] CreateandCategoryDto productDto)
        {
            return Ok(await _categoryService.AddCategoryProduct(productDto));
        }
    }
}
