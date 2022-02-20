using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace övning_generics
{
    public class lghSameProp : EqualityComparer<lgh>
    {
        public override bool Equals([AllowNull] lgh x, [AllowNull] lgh y)
        {
            if (x.ID == y.ID && x.LghNr == y.LghNr && x.Antal == y.Antal)
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
            return hCode.GetHashCode();
        }
    }
}
