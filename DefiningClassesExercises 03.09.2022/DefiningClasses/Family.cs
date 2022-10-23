using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            members = new List<Person>();
        }
        private List<Person> members;

        public List<Person> Members
        {
            get { return members; }
        }
        public void AddMember(Person person)
        {
            members.Add(person);
        }

        public Person GetOldestMember()
        {
            return members.OrderByDescending(x => x.Age).ToList()[0];
        }
    }
}
