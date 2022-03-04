using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _02___Linq
{
    public class TeachersSubject
    {
        [Key]
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}