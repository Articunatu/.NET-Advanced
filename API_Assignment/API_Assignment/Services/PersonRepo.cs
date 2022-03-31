using API_Assignment.Data;
using API_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment.Services
{
    public class PersonRepo : IService<Person>
    {
        private ApiDbContext _apiContext;
        public PersonRepo(ApiDbContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Person> Create(Person Entity)
        {
            var newPerson = await _apiContext.Persons.AddAsync(Entity);
            await _apiContext.SaveChangesAsync();
            return newPerson.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var delPerson = await _apiContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id);
            _apiContext.Persons.Remove(delPerson);
            await _apiContext.SaveChangesAsync();
            return delPerson;
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            return await _apiContext.Persons.ToListAsync();
        }

        public Task<IEnumerable<object>> ReadConnectedEntities(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> ReadSingle(int id)
        {
            return await _apiContext.Persons.FirstOrDefaultAsync(p => p.PersonID == id);
        }

        public async Task<IEnumerable<Object>> Search(string name)
        {
            var NamedPersons = (from p in _apiContext.Persons
                                join a in _apiContext.Addresses
                                on p.AddressID equals a.AddressID
                                where p.FirstName == name
                                select new
                                {
                                    Förnamn = p.FirstName,
                                    Efternamn = p.LastName,
                                    Adress = a.AddressName,
                                    Postnummer = a.PostalCode
                                }).ToArrayAsync();
            return await NamedPersons;
        }

        public async Task<Person> Update(Person Entity)
        {

            var uptPerson = await _apiContext.Persons.FirstOrDefaultAsync(p => p.PersonID == Entity.PersonID);
            if (uptPerson != null)
            {
                uptPerson.AddressID = Entity.AddressID;
                uptPerson.Password = Entity.Password;
                uptPerson.ConfirmPassword = Entity.Password;
                await _apiContext.SaveChangesAsync();

                return uptPerson;
            }
            return null;
        }
    }
}
