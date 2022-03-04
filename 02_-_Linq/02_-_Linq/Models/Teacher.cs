using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _02___Linq
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClassID { get; set; }
    }
}