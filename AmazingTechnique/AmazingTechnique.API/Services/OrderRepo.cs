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

        public async Task<Order> Create(Order newEntity)
        {
            var added = await _appDbContext.Orders.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return added.Entity;
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

        public async Task<Order> Update(Order Entity)
        {
            var result = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.OrderID == Entity.OrderID);
            if (result != null)
            {
                result.OrderPlaced = Entity.OrderPlaced;
                result.CustomerID = Entity.CustomerID;
                result.Customer = Entity.Customer;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Order> Delete(int id)
        {
            var result = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.OrderID == id);
            if (result == null)
            {
                _appDbContext.Orders.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
