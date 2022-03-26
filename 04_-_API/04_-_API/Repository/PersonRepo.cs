using _04___API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _04___API.Repository
{
    public class PersonRepo : IRepository<Person>
    {
        private WebDbContext _webDbContext;

        public PersonRepo(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public async Task<Person> Create(Person newEntity)
        {
            var result = await _webDbContext.Persons.AddAsync(newEntity);
            await _webDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            return await _webDbContext.Persons.ToListAsync();
        }

        public async Task<Person> ReadSingle(int id)
        {
            return await _webDbContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id);
        }

        public async Task<Person> Update(Person Entity)
        {
            var result = await _webDbContext.Persons.FirstOrDefaultAsync(p => p.PersonID == Entity.PersonID);
            if (result != null)
            {
                result.Name = Entity.Name;
                result.Interests = Entity.Interests;
                result.PhoneNumber = Entity.PhoneNumber;

                await _webDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await _webDbContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id);
            if (result != null)
            {
                _webDbContext.Persons.Remove(result);
                await _webDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public Task<object> SearchByPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> ConnectToPerson(Person Entity, int pId, int iId)
        {
            throw new NotImplementedException();
        }
    }
}
