using System;
using _06.FoodShortage.Interfaces;

namespace _06.FoodShortage.Models
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
