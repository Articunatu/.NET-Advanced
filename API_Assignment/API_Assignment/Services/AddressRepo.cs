using API_Assignment.Data;
using API_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Assignment.Services
{
    public class AddressRepo : IService<Address>
    {
        private ApiDbContext _apiContext;
        public AddressRepo(ApiDbContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Address> Create(Address Entity)
        {
            var newAddress = await _apiContext.Addresses.AddAsync(Entity);
            await _apiContext.SaveChangesAsync();
            return newAddress.Entity;
        }

        public async Task<Address> Delete(int id)
        {
            var delAddress = await _apiContext.Addresses.FirstOrDefaultAsync(a => a.AddressID == id);
            _apiContext.Addresses.Remove(delAddress);
            await _apiContext.SaveChangesAsync();
            return delAddress;
        }

        public async Task<IEnumerable<Address>> ReadAll()
        {
            return await _apiContext.Addresses.ToListAsync();
        }

        public Task<IEnumerable<object>> ReadConnectedEntities(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> ReadSingle(int id)
        {
            return await _apiContext.Addresses.FirstOrDefaultAsync(a => a.AddressID == id);
        }

        public Task<IEnumerable<Object>> Search(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> Update(Address Entity)
        {
            var uptAddress = await _apiContext.Addresses.FirstOrDefaultAsync(a => a.AddressID == Entity.AddressID);
            uptAddress.AddressName = Entity.AddressName;
            uptAddress.PostalCode = Entity.PostalCode;
            await _apiContext.SaveChangesAsync();
            return uptAddress;
        }
    }
}
