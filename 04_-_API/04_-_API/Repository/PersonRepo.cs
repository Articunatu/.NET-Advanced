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
        public PersonRepo(WebDbContext webDbContext)
        {
            Repo._webDbContext = webDbContext;
        }

        public async Task<Person> Create(Person newEntity)
        {
            var result = await Repo._webDbContext.Persons.AddAsync(newEntity);
            await Repo._webDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Person>> ReadAll(int id)
        {
            return await Repo._webDbContext.Persons.ToListAsync();
        }

        public async Task<Person> ReadSingle(int id)
        {
            return await Repo._webDbContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id);
        }

        public async Task<Person> Update(Person Entity)
        {
            var result = await Repo._webDbContext.Persons.FirstOrDefaultAsync(p => p.PersonID == Entity.PersonID);
            if (result != null)
            {
                result.Name = Entity.Name;
                result.Interests = Entity.Interests;
                result.PhoneNumber = Entity.PhoneNumber;

                await Repo._webDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await Repo._webDbContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id);
            if (result != null)
            {
                Repo._webDbContext.Persons.Remove(result);
                await Repo._webDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }     
    }
}
