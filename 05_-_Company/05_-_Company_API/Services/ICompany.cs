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
    }

    public interface IEmployee
    {
        Task<Employee> Create(Employee newEmp);
        Task<Employee> Read(int id); Task<IEnumerable<Employee>> ReadAll();
        Task<Employee> Update(Employee uptEmp, int id);
        Task<Employee> Delete(Employee delEmp);
        Task<IEnumerable<Employee>> ProjectsEmployees(int id);
        Task<object> WeeklyHours(int week, int id);
    }
}