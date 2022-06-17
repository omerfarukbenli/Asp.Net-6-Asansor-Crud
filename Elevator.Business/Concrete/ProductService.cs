using AutoMapper;
using Elevator.Business.Abstract;
using Elevator.Data.Abstract;
using Elevator.Entities.Dto;
using Elevator.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Business.Concrete
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> AddProductAndCategory(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            
            
            await _productRepository.AddProduct(product);

            foreach (var category in productDto.Categories)
            {
                await _productRepository.AddProductCategory(product.Id, category);
            }
            return product;
        }

        public async Task<GetProductForListDto> GetProductAndCategory(int id)
        {
            return _mapper.Map<GetProductForListDto>(await _productRepository.GetProductWithCategory(id));
        }

        public async Task<GetProductWithAttributeDto> GetProductWithAttributeDto(int id)
        {
            return _mapper.Map<GetProductWithAttributeDto>(await _productRepository.GetProduct(id));
        }

        public async Task<UpdateProductDto> UpdateProduct(UpdateProductDto product, int id)
        {
            var ownerEntity = await _productRepository.GetProduct(id);
            _mapper.Map<GetProductWithAttributeDto>(ownerEntity);
            _mapper.Map(product, ownerEntity);
            await _productRepository.UpdateProduct(id, ownerEntity);

            return product;
        }
    }
}
