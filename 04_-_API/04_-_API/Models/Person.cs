using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _04___API.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Interest> Interests { get; set; }
        public ICollection<WebLink> WebLinks { get; set; }
    }
}
