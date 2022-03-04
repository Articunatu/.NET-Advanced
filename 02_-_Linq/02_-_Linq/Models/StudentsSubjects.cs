using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _02___Linq
{
    public class StudentsSubjects
    {
        [Key]
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}