using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _02___Linq
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string ClassName { get; set; }
    }
}
