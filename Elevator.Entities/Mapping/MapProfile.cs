using AutoMapper;
using Elevator.Entities.Dto;
using Elevator.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Entities.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, GetListCategory>().ReverseMap();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            //CreateMap<ProductAttribute, CreateProductAttributeDto>().ReverseMap();




            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>()
                .ForMember(dest => dest.Categories, opt =>
               opt.MapFrom(src => src.ProductWithCategories.Select(x => new CreateProductCategoryDto { CategoryID = x.CategoryID, ProductID = x.ProductID })))
               .ReverseMap();
            CreateMap<Category, CreateandCategoryDto>()
                .ForMember(dest => dest.Products, opt =>
                opt.MapFrom(src => src.ProductWithCategories.Select(x => new CreateProductCategoryDto { CategoryID = x.CategoryID, ProductID = x.ProductID })))
                .ReverseMap();





            CreateMap<Product, GetProductForListDto>()
              .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.ProductName))
              .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
              .ForMember(x => x.Categories, opt => opt.MapFrom(src => src.ProductWithCategories.Select(x => x.Category.Name)));

            CreateMap<Product, GetProductWithAttributeDto>()
               .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.ProductName))
              .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
              .ForMember(x => x.Attributes, opt => opt.MapFrom(src => src.ProductAttributes));

            CreateMap<ProductAttribute, ProductAttributeDto>();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
