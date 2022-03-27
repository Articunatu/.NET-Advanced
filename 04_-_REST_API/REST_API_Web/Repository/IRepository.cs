using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Web.Repository
{
    public interface IRepository<T>
    {
        Task<T> Create(T newEntity);
        Task<T> ReadSingle(int id); Task<IEnumerable<T>> ReadAll();
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
        Task<object> SearchByPerson(int id);
        Task<T> ConnectToPerson(T Entity, int pId, int iId);
    }
}
