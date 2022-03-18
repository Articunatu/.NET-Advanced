using _04___API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _04___API.Repository
{
    public class InterestRepo : IRepository<Interest>
    {
        public Task<Interest> Create(Interest newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Interest>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<Interest> ReadSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Interest> Update(Interest Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Interest> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
