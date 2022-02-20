using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01___Generic_Box
{
    class BoxEnumerator : IEnumerator<Box>
    {
        public BoxCollection boxes;
        public int curIndex;
        public Box curBox;
        public int Count
        {
            get
            {
                return boxes.Count;
            }
        }

        public BoxEnumerator(BoxCollection _boxes)
        {
            boxes = _boxes;
            curIndex = -1;
            curBox = default;
        }

        public Box Current { get { return curBox; } }

        object IEnumerator.Current { get { return curIndex; } }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (++curIndex >= boxes.Count())
            {
                return false;
            }
            else
            {
                curBox = boxes[curIndex];
            }
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
