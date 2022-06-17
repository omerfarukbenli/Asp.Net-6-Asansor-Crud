using Elevator.Data.Abstract;
using Elevator.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Data.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddProductCategory(int id, int cat)
        {
            var category = _context.Categories.Find(cat);

            var product = _context.Products.FirstOrDefault(a => a.Id == id);

            ProductWithCategory newQuestCat = new ProductWithCategory
            {
                Category = category,
                Product = product
            };
            await _context.Set<ProductWithCategory>().AddAsync(newQuestCat);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.Include(a => a.ProductAttributes).FirstOrDefaultAsync(q => q.Id == id);
            return product;
        }

        public async Task<Product> GetProductWithCategory(int id)
        {
            var product = await _context.Products.Include(a => a.ProductWithCategories).ThenInclude(a => a.Category).FirstOrDefaultAsync(q => q.Id == id);
            return product;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<Product> UpdateProduct(Product item, int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(int id, Product ownerEntity)
        {
            if (ownerEntity == null)
            {
                throw new ArgumentNullException("item");
            }

            var product = _context.Products.Include(p => p.ProductAttributes).FirstOrDefaultAsync(q => q.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException("product");
            }
            _context.Products.Update(ownerEntity);
            _context.SaveChanges();
            return product;
        }
       
    }
}
