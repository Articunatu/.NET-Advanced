using _04___API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _04___API.Repository
{
    public class WeblinkRepo : IRepository<WebLink>
    {
        public Task<WebLink> Create(WebLink newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WebLink>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<WebLink> ReadSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WebLink> Update(WebLink Entity)
        {
            throw new NotImplementedException();
        }

        public Task<WebLink> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
