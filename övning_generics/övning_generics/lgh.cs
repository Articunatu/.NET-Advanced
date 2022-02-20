using System;
using System.Collections.Generic;
using System.Text;

namespace övning_generics
{
    public class lgh : IEquatable<lgh>
    {
        public lgh(int iD, int lghNr, int antal)
        {
            ID = iD;
            LghNr = lghNr;
            this.Antal = antal;
        }

        public int ID { get; set; }
        public int LghNr { get; set; }
        public int Antal { get; set; }

        
        bool IEquatable<lgh>.Equals(lgh lgh1)
        {
            if (new lghSameProp().Equals(this, lgh1))
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
