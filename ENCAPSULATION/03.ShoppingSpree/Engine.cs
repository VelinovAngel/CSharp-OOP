using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }


        public void Run()
        {
            try
            {
                ReadPeople();
                ReadProducts();
                ReadInput();
                Print();

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void ReadPeople()
        {
            //Pesho=11;Gosho=4
            string[] tokens = Console
                .ReadLine()
                .Split(';')
                .ToArray();

            foreach (var item in tokens)
            {
                string[] peopleArg = item
                    .Split('=')
                    .ToArray();

                string personName = peopleArg[0];
                decimal personMoney = decimal.Parse(peopleArg[1]);

                Person person = new Person(personName, personMoney);

                people.Add(person);
            }
        }

        private void ReadProducts()
        {
            string[] tokens = Console
                .ReadLine()
                .Split(';',StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var item in tokens)
            {
                string[] productsArg = item
                    .Split('=')
                    .ToArray();

                string productName = productsArg[0];
                decimal productPrice = decimal.Parse(productsArg[1]);

                Product product = new Product(productName, productPrice);
                products.Add(product);
            }

        }

        private void ReadInput()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(' ');

                string personName = tokens[0];
                string productName = tokens[1];

                Person person = this.people.FirstOrDefault(p => p.Name == personName);
                Product product = this.products.FirstOrDefault(p => p.Name == productName);

                if (person != null && product != null)
                {
                    string result = person.BuyProduct(product);
                    Console.WriteLine(result);
                }

            }
        }

        private void Print()
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
