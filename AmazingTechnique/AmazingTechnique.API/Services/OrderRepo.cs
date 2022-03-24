using AmazingTechnique.API.Model;
using AmazingTechnique.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTechnique.API.Services
{
    public class OrderRepo : IAmazingTechnique<Order>
    {
        private AppDbContext _appDbContext;

        public OrderRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Order> Create(Order newEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> ReadAll()
        {
            return await _appDbContext.Orders.Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order> ReadSingle(int id)
        {
            ///ThenInclude() for many to many relations
            return await _appDbContext.Orders.FirstOrDefaultAsync(p => p.OrderID == id);
        }

        public Task<Order> Update(Order Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
