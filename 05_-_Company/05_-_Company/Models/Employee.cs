using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05___Company_DB.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Anställdas förnamn måste vara med!")]
        [StringLength(22, MinimumLength = 1, ErrorMessage = "Ett förnamn kan ej vara längre än 22 bokstäver långt!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Anställdas efternamn måste vara med!")] 
        [StringLength(22, MinimumLength = 2, ErrorMessage = "Ett efternamn kan ej vara längre än 22 bokstäver långt!")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Anställdas personnnummer måste anges!")]
        public string SecurityNumber { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
    }
}