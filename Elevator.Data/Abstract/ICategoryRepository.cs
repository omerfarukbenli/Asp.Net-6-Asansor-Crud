using Elevator.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Data.Abstract
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<List<Category>> GetCategories(string searchTerm); //adını yazdığımızda getir
        Task<List<Category>> GetCategoriesId(int id); //id yazdığımızda getir
        Task<Category> CategoryExists(string name);
        Task<Category> Update(Category category, int id);
        Task<Category> CategoryExistsId(int id);
        Task<Category> GetCategory(int id); //tekil getir
        Task Delete(Category category);
        Task<List<Category>> GetAll();


        //////////
        Task AddCategoryProduct(int id, int pro);
    }
}
