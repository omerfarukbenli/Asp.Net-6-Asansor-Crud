using Elevator.Entities.Dto;
using Elevator.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Business.Abstract
{
    public interface IProductService
    {
        Task<Product> AddProductAndCategory(CreateProductDto product);
        Task<GetProductForListDto> GetProductAndCategory(int id);
        Task<GetProductWithAttributeDto> GetProductWithAttributeDto(int id);

        Task<UpdateProductDto> UpdateProduct(UpdateProductDto product, int id);
    }
}
