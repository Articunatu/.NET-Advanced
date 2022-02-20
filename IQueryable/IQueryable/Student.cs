using System;
using System.Collections.Generic;
using System.Text;

namespace IQueryable
{
    public class Student : IEquatable<Student>
    {
        public int ID { get; set; }
        public int Grade { get; set; }
        public int Total { get; set; }

        public Student(int id, int grade, int total)
        {
            this.ID = id;
            this.Grade = grade;
            this.Total = total;
        }

        bool IEquatable<Student>.Equals(Student other)
        {
            if (new StudenSameProp().Equals(this, other))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
