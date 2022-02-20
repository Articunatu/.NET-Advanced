using System;
using System.Collections.Generic;
using System.Text;

namespace IQueryable
{
    public class StudentCollection : ICollection<Student>
    {
        public IEnumerator<Student> GetEnumerator()
        {

        }
    }
}
