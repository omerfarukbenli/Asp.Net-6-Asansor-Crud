using AutoMapper;
using Elevator.Business.Abstract;
using Elevator.Data.Abstract;
using Elevator.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elevator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductRepository productRepository, IProductService productService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDto productDto)
        {
            return Ok(await _productService.AddProductAndCategory(productDto));
        }
        [HttpGet("ProductWithCategory")]
        public async Task<ActionResult> GetCategoryId(int id)
        {
            return Ok(await _productService.GetProductAndCategory(id));
        }
        [HttpGet("ProductWithAttribute")]
        public async Task<ActionResult> GetProductWithAttributes(int id)
        {
            return Ok(await _productService.GetProductWithAttributeDto(id));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto item)
        {
            return Ok(await _productService.UpdateProduct(item, id));
        }
    }
}
