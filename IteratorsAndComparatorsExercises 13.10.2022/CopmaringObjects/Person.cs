using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CopmaringObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }
        public Person(params string[] personInfo)
        {
            this.name = personInfo[0];
            this.age = int.Parse(personInfo[1]);
            this.town = personInfo[2];
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.name);
            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
                if (result == 0)
                {
                    result = this.town.CompareTo(other.town);
                }
            }
            return result;
        }
    }
}
