using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private int difference;

        public int Difference
        {
            get { return difference; }
        }

        public void CalculateDifference (string firstDate, string secondDate)
        {
            string[] fistDateInfo = firstDate.Split(" ");
            int firstDateYear = int.Parse(fistDateInfo[0]);
            int firstDateMonth = int.Parse(fistDateInfo[1]);
            int firstDateDay = int.Parse(fistDateInfo[2]);
            DateTime first = new DateTime(firstDateYear, firstDateMonth, firstDateDay);

            string[] secondDateInfo = secondDate.Split(" ");
            int secondDateYear = int.Parse(secondDateInfo[0]);
            int secondDateMonth = int.Parse(secondDateInfo[1]);
            int secondDateDay = int.Parse(secondDateInfo[2]);
            DateTime second = new DateTime(secondDateYear, secondDateMonth, secondDateDay);

           TimeSpan difference = first.Subtract(second);
            int days = difference.Days;

            this.difference = Math.Abs(days);
        }
    }
}
