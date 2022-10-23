using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake :IEnumerable<int>
    {
        private int[] stones;
        private int length;
        public Lake(params int[] stones)
        {
            this.stones = stones;
            length = stones.Length;
        }

        public int Length
        {
            get { return length; }
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.length; i++)
            {
                if (i%2==0)
                {
                    yield return stones[i];
                }
            }

            for (int i = this.length - 1; i >= 0; i--)
            {
                if (i%2!=0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
