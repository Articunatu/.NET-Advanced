using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Förnamn är ett krav")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Förnamn måste vara mellan 2 och 25 bokstäver")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Efternamn är ett krav")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Efternamn måste vara mellan 2 och 25 bokstäver")]
        public string LastName { get; set; }
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        [Required(ErrorMessage = "Lösenord är ett krav!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lösenordet måste även bekräftas!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lösenorden matchar ej varandra")]
        public string ConfirmPassword { get; set; }
    }
}
