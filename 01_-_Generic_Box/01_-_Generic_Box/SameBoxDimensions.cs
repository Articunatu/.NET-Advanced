using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _01___Generic_Box
{
    public class SameBoxDimensions : EqualityComparer<Box>
    {
        public override bool Equals([AllowNull] Box x, [AllowNull] Box y)
        {
            if (x.Base == y.Base && x.Height == y.Height && x.Length == y.Length)
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
            Console.WriteLine("HC: {0}", hCode.GetHashCode());
            return hCode.GetHashCode();
        }
    }
}
