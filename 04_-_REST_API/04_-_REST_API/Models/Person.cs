using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _04___REST_API.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Interest> Interests { get; set; }
        //public ICollection<Weblink> Weblinks { get; set; }
    }
}
