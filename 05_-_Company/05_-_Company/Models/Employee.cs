using System.ComponentModel.DataAnnotations;

namespace _05___Company_DB.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string SecurityNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
