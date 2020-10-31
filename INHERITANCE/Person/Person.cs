﻿using System;
namespace Person
{
    public class Person
    {
        //private string name;
        //private int age;


        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }

    }
}
