using _04___API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _04___API.Repository
{
    public class PersonRepo : IRepository<Person>
    {
        public Task<Person> Create(Person newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Person> ReadSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Update(Person Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Delete(int id)
        {
            throw new NotImplementedException();
        }     
    }
}
