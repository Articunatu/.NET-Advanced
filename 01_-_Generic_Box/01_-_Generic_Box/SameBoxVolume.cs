using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _01___Generic_Box
{
    public class SameBoxVolume : EqualityComparer<Box>
    {
        public override bool Equals([AllowNull] Box x, [AllowNull] Box y)
        {
            if (x.Base * x.Height * x.Length == y.Base * y.Height * y.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode([DisallowNull] Box obj)
        {
            var hCode = obj.Base ^ obj.Height ^ obj.Length;
            return hCode.GetHashCode();
        }
    }
}
