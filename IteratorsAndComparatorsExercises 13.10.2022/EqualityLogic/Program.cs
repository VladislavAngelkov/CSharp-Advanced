using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesOfInput = int.Parse(Console.ReadLine());

            HashSet<Person> hashPersons = new HashSet<Person>();
            SortedSet<Person> sortedPersons = new SortedSet<Person>();

            for (int i = 0; i < linesOfInput; i++)
            {
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = string.Join(" ", personInfo.Take(personInfo.Length - 1));
                int age = int.Parse(personInfo[personInfo.Length - 1]);
                Person person = new Person(name, age);

                hashPersons.Add(person);
                sortedPersons.Add(person);
            }

            Console.WriteLine(hashPersons.Count);
            Console.WriteLine(sortedPersons.Count);

        }

        public class Person : IComparable<Person>
        {
            private string name;
            private int age;

            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public Person(params string[] personInfo)
            {
                this.name = personInfo[0];
                this.age = int.Parse(personInfo[1]);
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

            public int CompareTo(Person other)
            {
                int result = this.name.CompareTo(other.name);
                if (result == 0)
                {
                    result = this.age.CompareTo(other.age);
                }
                return result;
            }

            public override int GetHashCode()
            {
               
                return this.name.GetHashCode() + this.age;
            }

            public override bool Equals(object obj)
            {
                Person otherPerson = obj as Person;

                if (otherPerson == null)
                {
                    return false;
                }

                return this.name == otherPerson.name && this.age == otherPerson.age;
            }
        }
    }
}
