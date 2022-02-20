using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IQueryable
{
    public class StudenSameProp : EqualityComparer<Student>
    {
        public override bool Equals([AllowNull] Student U1, [AllowNull] Student U2)
        {
            if (U1.ID == U2.ID && U1.Grade == U2.Grade && U1.Total == U2.Total )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode([DisallowNull] Student stud)
        {
            var hCode = stud.ID ^ stud.Grade ^ stud.Total;
            return hCode.GetHashCode();
        }
    }
}
