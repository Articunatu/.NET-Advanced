using Assignment_EasyAPi.Data;
using Assignment_EasyAPi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_EasyAPi.Repository
{
    public class PersonRepo : IRepository<Person>
    {
        private EasyDBContext _context;

        public PersonRepo(EasyDBContext context)
        {
            _context = context;
        }
        public async Task<Person> Create(Person person)
        {
            var created = await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<Person> Read(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> Update(Person person)
        {
            var result = await _context.Persons.FirstOrDefaultAsync(p => p.ID == person.ID);
            if (result != null)
            {
                result.Class = person.Class;
                result.Type1 = person.Type1;
                result.Type2 = person.Type2;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Person> Delete(Person deleted)
        {
            if (deleted != null)
            {
                _context.Persons.Remove(deleted);
                await _context.SaveChangesAsync();
            }
            return null;
        }
    }
}
