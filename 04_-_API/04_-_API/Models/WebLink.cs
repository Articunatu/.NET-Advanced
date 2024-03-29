﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _04___API.Models
{
    public class WebLink
    {
        [Key]
        public int? WebID { get; set; }
        public string LinkURL { get; set; }
        
        public int? PersonID { get; set; }
        
        public int? InterestID { get; set; }
        //[ForeignKey("InterestID")]
        public Person Person { get; set; }
        //[ForeignKey("PersonID")]
        public Interest Interest { get; set; }
    }
}
