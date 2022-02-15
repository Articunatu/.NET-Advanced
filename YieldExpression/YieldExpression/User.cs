using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace YieldExpression
{
    class User : IEnumerable<bool>
    {
        public IEnumerator<bool> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
