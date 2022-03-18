using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _04___API.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }

        public ICollection<Interest> Interests { get; set; }
        public ICollection<WebLink> WebLinks { get; set; }
    }
}
