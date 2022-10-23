using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace EqualityLogic
{
    //public class Person : IComparable<Person>
    //{
    //    private string name;
    //    private int age;

    //    public Person(string name, int age)
    //    {
    //        this.name = name;
    //        this.age = age;
    //    }
    //    public Person(params string[] personInfo)
    //    {
    //        this.name = personInfo[0];
    //        this.age = int.Parse(personInfo[1]);
    //    }

    //    public string Name
    //    {
    //        get { return name; }
    //        set { name = value; }
    //    }
    //    public int Age
    //    {
    //        get { return age; }
    //        set { age = value; }
    //    }

    //    public int CompareTo(Person other)
    //    {
    //        int result = this.name.ToLower().CompareTo(other.name.ToLower());
    //        if (result == 0)
    //        {
    //            result = this.age - other.age;
    //        }
    //        return result;
    //    }

    //    public override int GetHashCode()
    //    {
            
    //        return (this.name.ToLower().GetHashCode())*10 + this.age;
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        Person otherPerson = obj as Person;

    //        return this.name.ToLower() == otherPerson.name.ToLower() && this.age == otherPerson.age;
    //    }
    //}
}
