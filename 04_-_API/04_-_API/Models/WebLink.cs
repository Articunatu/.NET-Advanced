using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _04___API.Models
{
    public class WebLink
    {
        [Key]
        public int WebID { get; set; }
        public string LinkURL { get; set; }

        public int PersonID { get; set; }
        public int InterestID { get; set; }
        public Person Person { get; set; }
        public Interest Interest { get; set; }
    }
}
