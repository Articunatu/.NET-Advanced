using AmazingTechnique.API.Model;
using AmazingTechnique.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTechnique.API.Services
{
    public class ProductRepo : IAmazingTechnique<Product>
    {
        private AppDbContext _appContext;
        public ProductRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Product> Create(Product newEntity)
        {
            var result = await _appContext.Products.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> Delete(int id)
        {
            var result = await _appContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if (result != null)
            {
                _appContext.Products.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> ReadAll()
        {
            return await _appContext.Products.ToListAsync();
        }

        public async Task<Product> ReadSingle(int id)
        {
            return await _appContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
        }

        public async Task<Product> Update(Product Entity)
        {
            var result = await _appContext.Products.FirstOrDefaultAsync(p => p.ProductID == Entity.ProductID);
            if (result != null)
            {
                result.ProductName = Entity.ProductName;
                result.Price = Entity.Price;
                result.Category = Entity.Category;

                await _appContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
