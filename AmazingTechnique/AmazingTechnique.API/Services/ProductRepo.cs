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
        public Task<Product> Create(Product newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> ReadAll()
        {
            return await _appContext.Products.ToListAsync();
        }

        public Task<Product> ReadSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product Entity)
        {
            throw new NotImplementedException();
        }
    }
}
