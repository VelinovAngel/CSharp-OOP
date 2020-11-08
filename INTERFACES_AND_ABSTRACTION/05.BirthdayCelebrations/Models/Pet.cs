using System;
using _05.BirthdayCelebrations.Interfaces;

namespace _05.BirthdayCelebrations.Models
{
    public class Pet : IName , IBirhdates
    {
        //private string name;
        //private DateTime birthdata;


        public Pet(string name , string birthdata)
        {
            this.Name = name;
            this.Birthdate = DateTime.ParseExact(birthdata, "dd/mm/yyyy", null);
        }

        public string Name { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
