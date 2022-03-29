using _05___Company_API.Database;
using _05___Company_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___Company_API.Services
{
    public class EmployeeRepo : IEmployee<Employee>
    {
        private CompanyDbContext _context;

        public EmployeeRepo(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee newEmployee)
        {
            
        }

        public Task Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Employee updEmployee, int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Employee delEmployee)
        {
            throw new NotImplementedException();
        }

        public Task HoursPerEmployeesWeek(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task ProjectsEmployees(Project project)
        {
            throw new NotImplementedException();
        }

        async Task IEmployee<Employee>.Create(Employee newEmployee)
        {
            var created = await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return created;
        }
    }
}
