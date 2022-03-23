using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Validation
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage ="Förnamn är ett krav")]
        [StringLength(20,MinimumLength =3, ErrorMessage ="Förnamn måste vara mellan 3 och 20 bokstäver")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Efternamn är ett krav")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Efternamn måste vara mellan 3 och 30 bokstäver")]
        public string LastName { get; set; }
        [Range(18,50,ErrorMessage ="Ålder måste vara mellan 18 och 50")]
        public int Age { get; set; }
        [Range(typeof(DateTime), "01-01-2000", "31-12-2010",
            ErrorMessage ="Födelsedatumet måste vara mellan 01-01-2000 och 31-12-2010")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [MinLength(5)]
        [MaxLength(25)]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^([A-za-Z]+[\s]{1}[A-za-Z]+|([A-za-Z]+)$")]
        public string PostalCode { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "Lösenord är ett krav")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Det är ett krav att bekräfta lösenordet")]
        [Compare("Password", ErrorMessage = "Lösenorden matchar inte varandra")]
        public string ConfirmPassword { get; set; }
    }
}
