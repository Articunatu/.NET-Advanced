using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _01___Generic_Box
{
    public class Box : IEquatable<Box>
    {
        public Box(int _height, int _base, int _width)
        {
            Height = _height;
            Base = _base;
            Length = _width;
        }

        public int Height { get; set; }
        public int Base { get; set; }
        public int Length { get; set; }


        public bool Equals([AllowNull] Box other)
        {
            if (new SameBoxDimensions().Equals(other, this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EqualsVol([AllowNull] Box other)
        {
            if (new SameBoxVolume().Equals(other, this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
