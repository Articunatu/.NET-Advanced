using _05___Company_API.Database;
using _05___Company_DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05___Company_API.Services
{
    public class EmployeeRepo : IEmployee
    {
        private CompanyDbContext _context;

        public EmployeeRepo(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee newEmployee)
        {
            var created = await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<Employee> Read(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<IEnumerable<Employee>> ReadAll()
        {
            return await _context.Employees.ToArrayAsync();
        }

        public async Task<Employee> Update(Employee uptEmployee)
        {
            var updated = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == uptEmployee.EmployeeID);
            updated.Address = uptEmployee.Address;
            updated.PhoneNumber = uptEmployee.PhoneNumber;
            updated.PostalCode = uptEmployee.PostalCode;
            updated.Salary = uptEmployee.Salary;
            updated.SecurityNumber = uptEmployee.SecurityNumber;
            await _context.SaveChangesAsync();
            return uptEmployee;
        }

        public async Task<Employee> Delete(Employee delEmployee)
        {
            var deleted = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == delEmployee.EmployeeID);
            _context.Employees.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }

        public async Task<IEnumerable<Employee>> ProjectsEmployees(int id)
        {
            var employees = (from e in _context.Employees
                             join t in _context.TimeReports
                             on e.EmployeeID equals t.EmployeeID
                             join p in _context.Projects
                             on t.ProjectID equals p.ProjectID
                             where p.ProjectID == id
                             select e
                           ).Distinct().ToListAsync();
            return await employees;
        }

        public async Task<object> WeeklyHours(int week, int id)
        {
            int totalHours = (from t in _context.TimeReports
                              join e in _context.Employees
                              on t.EmployeeID equals e.EmployeeID
                              where t.EmployeeID == id
                              where t.Week == week
                              select t.Hours).ToArray().Sum();

            //foreach (var item in hours) ///Better performance
            //{
            //    totalHours += item;
            //}

            var empHours = (from t in _context.TimeReports
                            join e in _context.Employees
                            on t.EmployeeID equals e.EmployeeID
                            where t.EmployeeID == id
                            select new
                            {
                                Anställd = e.FirstName + " " + e.LastName,
                                Veckotimmar = totalHours
                            }).Distinct().ToArrayAsync();

            return await empHours;
        }
    }
}