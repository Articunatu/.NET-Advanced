using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace övning_generics
{
    public class lghEnumerator : IEnumerator<lgh>
    {
        public lghCollection _lgh;
        public int curIndex;
        public lgh curLgh;
        public int Count
        {
            get
            {
                return _lgh.Count;
            }
        }

        public lghEnumerator(lghCollection lgh)
        {
            this._lgh = lgh;
            this.curIndex = -1;
            this.curLgh = default(lgh);
        }

        public lgh Current { get { return curLgh; } }

        object IEnumerator.Current { get { return curIndex; } }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }




        public bool MoveNext()
        {
            if (++curIndex >= _lgh.Count())
            {
                return false;
            }
            else
            {
                curLgh = _lgh[curIndex];
            }
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
