using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment.Services
{
    public interface IService<T>
    {
        Task<T> Create(T Entity);
        Task<T> ReadSingle(int id); Task<IEnumerable<T>> ReadAll();
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
        Task<IEnumerable<Object>> Search(string name);
        Task<IEnumerable<Object>> ReadConnectedEntities(int id);
    }
}
