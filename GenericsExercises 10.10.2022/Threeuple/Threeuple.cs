using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        
        public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
            this.thirdItem = thirdItem;
        }

        private T1 firstItem;
        private T2 secondItem;
        private T3 thirdItem;

        public T1 FirsItem
        {
            get { return firstItem; }
            set { firstItem = value; }
        }
        public T2 SecondItem
        {
            get { return secondItem; }
            set { secondItem = value; }
        }
        public T3 ThirdItem
        {
            get { return thirdItem; }
            set { thirdItem = value; }
        }
    }
}
