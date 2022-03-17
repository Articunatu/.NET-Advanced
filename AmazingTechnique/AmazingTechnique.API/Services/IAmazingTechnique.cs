using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTechnique.API.Services
{
    public interface IAmazingTechnique<T>
    {
        Task<T> Create(T newEntity);
        Task<IEnumerable<T>> ReadAll();
        Task<T> ReadSingle(int id);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
    }
}
