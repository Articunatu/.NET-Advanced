using _04___REST_API.EntityFramework;
using _04___REST_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Web.Repository
{
    public class PersonRepo : IRepository<Person>
    {
        private RestDbContext _restContext;

        public PersonRepo(RestDbContext webDbContext)
        {
            _restContext = webDbContext;
        }

        public async Task<Person> Create(Person newEntity)
        {
            var result = await _restContext.Persons.AddAsync(newEntity);
            await _restContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            return await _restContext.Persons.ToListAsync();
        }

        public async Task<Person> ReadSingle(int id)
        {
            return await _restContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id);
        }

        public async Task<Person> Update(Person Entity)
        {
            var result = await _restContext.Persons.FirstOrDefaultAsync(p => p.PersonID == Entity.PersonID);
            if (result != null)
            {
                result.Name = Entity.Name;
                result.Interests = Entity.Interests;
                result.PhoneNumber = Entity.PhoneNumber;

                await _restContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await _restContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id);
            if (result != null)
            {
                _restContext.Persons.Remove(result);
                await _restContext.SaveChangesAsync();
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
