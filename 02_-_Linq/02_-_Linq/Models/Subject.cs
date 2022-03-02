using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _02___Linq
{
    public class Subject
    {
        [Key]
        public int ID { get; set; }
        public string SubName { get; set; }
        public int Points { get; set; }
    }
}
