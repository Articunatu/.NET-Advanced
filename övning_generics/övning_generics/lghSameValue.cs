using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace övning_generics
{
    public class lghSameValue : EqualityComparer<lgh>
    {
        public override bool Equals([AllowNull] lgh x, [AllowNull] lgh y)
        {
            if ((x.ID,x.LghNr,x.Antal) == (y.ID,y.LghNr,y.Antal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
                
        public override int GetHashCode([DisallowNull] lgh obj)
        {
            var hCode = obj.ID ^ obj.LghNr ^ obj.Antal;
            Console.WriteLine("HC: {0}", hCode.GetHashCode());
            return hCode.GetHashCode();
        }
    }
}
