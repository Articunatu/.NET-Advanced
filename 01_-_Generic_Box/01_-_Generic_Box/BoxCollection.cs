using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01___Generic_Box
{
    public class BoxCollection : ICollection<Box>
    {
        public int Count { get { return listBoxes.Count; } }

        public bool IsReadOnly => throw new NotImplementedException();

        private List<Box> listBoxes;

        public BoxCollection()
        {
            listBoxes = new List<Box>();
        }

        public Box this[int index]
        {
            get { return listBoxes[index]; }
            set { listBoxes[index] = value; }
        }

        public void Add(Box item)
        {

            if (Contains(item))
            {
                Console.WriteLine("Det finns redan en låda med måtten: {0} x {1} x {2}", item.Base, item.Height, item.Length);
            }
            else
            {
                listBoxes.Add(item);
            }

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Box item)
        {
            bool isContain = false;
            foreach (Box box in listBoxes)
            {
                if (box.Equals(item))
                {
                    isContain = true;
                }
            }
            return isContain;
        }

        public void CopyTo(Box[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Box item)
        {
            if (listBoxes.Remove(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Box> GetEnumerator()
        {
            return new BoxEnumerator(this);
        }

        public void Display()
        {
            Console.WriteLine("\nBredd:\tHöjd:\tLängd:");
            foreach (var item in this)
            {
                Console.WriteLine("{0}\t{1}\t{2}", item.Base.ToString(), item.Height.ToString(), item.Length.ToString());
            }
        }
    }
}
