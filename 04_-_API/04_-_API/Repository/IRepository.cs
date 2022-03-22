using _04___API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _04___API.Repository
{
    public interface IRepository<T>
    {
        Task<T> Create(T newEntity);
        Task<T> ReadSingle(int id); Task<IEnumerable<T>> ReadAll(int? id);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);
    }

    public class Repo
    {
        static public WebDbContext _webDbContext;
    }
}
