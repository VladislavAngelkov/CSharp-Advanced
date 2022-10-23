using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T1, T2>
    {
        public Tuple(T1 firstItem, T2 secondItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
        }

        private T1 firstItem;
        private T2 secondItem;

        public T1 FirstItem
        {
            get { return firstItem; }
            set { firstItem = value; }
        }
        public T2 SecondItem
        {
            get { return secondItem; }
            set { secondItem = value; }
        }
    }
}
