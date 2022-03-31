using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string AddressName { get; set; }
        public int PostalCode { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
