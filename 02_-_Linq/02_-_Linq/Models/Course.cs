using System;
using System.Collections.Generic;
using System.Text;

namespace _02___Linq
{
    public class Course
    {
        public int ID { get; set; }
        public string ClassName { get; set; }

        public int StudentCount()
        {
            return 1;
        }
    }
}
