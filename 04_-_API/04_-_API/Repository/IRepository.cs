using System.Collections.Generic;
using System.Threading.Tasks;

namespace _04___API.Repository
{
    public interface IRepository<T>
    {
        Task<T> Create(T newEntity);
        Task<IEnumerable<T>> ReadAll();
        Task<T> ReadSingle(int id);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
    }
}
