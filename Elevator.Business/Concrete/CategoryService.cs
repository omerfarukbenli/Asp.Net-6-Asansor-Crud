using AutoMapper;
using Elevator.Business.Abstract;
using Elevator.Data.Abstract;
using Elevator.Entities.Dto;
using Elevator.Entities.Models;
using Elevator.Entities.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Business.Concrete
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CategoryDto> Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse<List<GetListCategory>>> GetAllCategory()
        {
            try
            {
                var a = await _unitOfWork.Categoryy.GetAll();
                var list = _mapper.Map<List<GetListCategory>>(a);
                var response = new Response<List<GetListCategory>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = list
                };

                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<GetListCategory>>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<List<GetCategoryDto>> GetCategories(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ValidationException("Search term cannot be empty");
            }
            return _mapper.Map<List<GetCategoryDto>>(await _unitOfWork.Categoryy.GetCategories(searchTerm));
        }

        public async Task<IResponse<List<GetCategoryDto>>> GetCategoriesID(int id)
        {
            var category = await _unitOfWork.Categoryy.GetCategoriesId(id);
            var list = _mapper.Map<List<GetCategoryDto>>(category);
            if (category.Count > 0)
            {
                return new Response<List<GetCategoryDto>>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = list
                };
            }
            else
            {
                return new Response<List<GetCategoryDto>>
                {
                    Message = "Böyle bir kategori bulunamadı.",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        public async Task<GetCategoryDto> Post(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var existingCat = await _unitOfWork.Categoryy.CategoryExists(categoryDto.Name);
            //
            if (string.IsNullOrWhiteSpace(categoryDto.Name))
            {
                throw new ValidationException("Category name cannot be null or empty");
            }

            if (existingCat != null)
            {
                var existingCategoryForGetDto = _mapper.Map<GetCategoryDto>(existingCat);
                return existingCategoryForGetDto;
            }
            await _unitOfWork.Categoryy.AddCategory(category);
            var categoryForGetDto = _mapper.Map<GetCategoryDto>(category);
            return categoryForGetDto;
        }

        public async Task<UpdateCategoryDto> Update(UpdateCategoryDto categoryDto, int id)
        {
            var ownerEntity = await _unitOfWork.Categoryy.GetCategory(id);
            _mapper.Map<GetCategoryDto>(ownerEntity);
            _mapper.Map(categoryDto, ownerEntity);
            await _unitOfWork.Categoryy.Update(ownerEntity, id);

            return categoryDto;
        }

        public Task<GetCategoryDto> Update(UpdateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
////////////////////////////////////////
        public async Task<Category> AddCategoryProduct(CreateandCategoryDto categoryDto)
        {
            var product = _mapper.Map<Category>(categoryDto);


            await _unitOfWork.Categoryy.AddCategory(product);

            foreach (var pr in categoryDto.Products)
            {
                await _unitOfWork.Categoryy.AddCategoryProduct(product.Id, pr);
            }
            return product;
        }

    }
}
