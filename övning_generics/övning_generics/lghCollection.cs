using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace övning_generics
{
    public class lghCollection : ICollection<lgh>
    {
        public int Count { get { return lghlist.Count; } }

        public bool IsReadOnly => throw new NotImplementedException();

        private List<lgh> lghlist;

        public lghCollection()
        {
            lghlist = new List<lgh>();
        }

        public lgh this[int index]
        {
            get { return (lgh)lghlist[index]; }
            set { lghlist[index] = value; }
        }

        public void Add(lgh item)
        {
            if (!Contains(item))
            {
                lghlist.Add(item);
            }
            else
            {
                Console.WriteLine("Item already exists in list");
                Console.ReadKey();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(lgh item)
        {
            bool found = false;
            foreach (lgh i in lghlist)
            {
                if (i.Equals(item))
                {
                    found = true;
                }
            }
            return found;
        }
        public bool Contains(lgh item, EqualityComparer<lgh> compare)
        {
            bool found = false;
            foreach (var i in lghlist)
            {
                if (compare.Equals(i, item))
                {
                    found = true;
                }
            }
            return found;
        }

        public void CopyTo(lgh[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }


        public bool Remove(lgh item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<lgh> GetEnumerator()
        {
            return new lghEnumerator(this);
        }
    }
}
