using _05___Company_API.Services;
using _05___Company_DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace _05___Company_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee _iemployee;
        public EmployeeController(IEmployee iemployee)
        {
            _iemployee = iemployee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee newEmployee)
        {
            try
            {
                if (newEmployee == null)
                {
                    return BadRequest();
                }
                var createdProduct = await _iemployee.Create(newEmployee);
                return CreatedAtAction(nameof(ReadEmployee), new { id = createdProduct.EmployeeID }, createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to create new employee to database.....");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> ReadEmployee(int id)
        {
            try
            {
                var readEmployee = await _iemployee.Read(id);
                if (readEmployee == null)
                {
                    return NotFound();
                }
                return readEmployee;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to retrieve the chosen employee from database.....");
            }
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> ReadAllEmployees()
        {
            try
            {
                return Ok(await _iemployee.ReadAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve employees from database.....");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee uptEmployee)
        {
            try
            {
                if (id != uptEmployee.EmployeeID)
                {
                    return BadRequest("Employee ID Doesn't Exist.....");
                }
                if (uptEmployee == null)
                {
                    return NotFound($"Emplyee with ID {id} Not Found........");
                }
                return await _iemployee.Update(uptEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to update employee to database.....");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var delEmployee = await _iemployee.Read(id);
                if (delEmployee == null)
                {
                    return NotFound($"Employee with ID {id} Not Found..........");
                }
                return await _iemployee.Delete(delEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error to delete employee from database.....");
            }
        }

        [HttpGet("project{projectId}")]
        public async Task<ActionResult<Employee>> ReadProjectsEmployees(int projectId)
        {
            try
            {
                return Ok(await _iemployee.ProjectsEmployees(projectId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve employees of this project from database.....");
            }
        }
        
        [HttpGet("week{week}/employee{eid}")]
        public async Task<ActionResult<object>> ReadHours(int week, int eid)
        {
            //try
            //{
            var employeesHours = await _iemployee.WeeklyHours(week, eid);
            if (employeesHours == null)
            {
                return NotFound();
            }
            return employeesHours;
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError,
            //                        "Error to retrieve the chosen week and employee from database.....");
            //}
        }
    }
}
