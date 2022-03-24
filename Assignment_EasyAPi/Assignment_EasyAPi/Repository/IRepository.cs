using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_EasyAPi.Repository
{
    public interface IRepository<T>
    {
        Task<T> Create(T Entity);

        Task<T> Read(int id);
        Task<IEnumerable<T>> ReadAll();
        
        Task<T> Update(T Entity, int id);
        Task<T> Delete(T Entity);
    }
}
