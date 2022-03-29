using _05___Company_DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _05___Company_API.Services
{
    public interface ICompany<T>
    {
        Task<T> Create(T Entity);
        Task<T> Read(int id); Task<IEnumerable<T>> ReadAll();
        Task<T> Update(T Entity, int id);
        Task<T> Delete(T Entity);
        Task<IEnumerable<T>> ProjectsEmployees(int id); 
        Task<T> WeeklyHours(T Entity, int id);
    }
}
