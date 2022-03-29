using _05___Company_DB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _05___Company_API.Services
{
    public interface IEmployee<Employee>
    {
        Task Create(Employee employee);
        Task Read(int id); Task<IEnumerable<Employee>> ReadAll();
        Task Update(Employee employee, int id);
        Task Delete(Employee employee);
        Task ProjectsEmployees(Project project);
        Task HoursPerEmployeesWeek(Employee employee);
    }
}
