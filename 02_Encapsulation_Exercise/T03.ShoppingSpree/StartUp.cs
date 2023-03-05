

namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personNameMoneyPair = Console.ReadLine().Split(";");
            string[] productNameCostPair = Console.ReadLine().Split(";");

            try
            {
                InitializePersons(personNameMoneyPair, persons);
                InitializeProducts(productNameCostPair, products);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);

                return;
            }

            BuyProducts(persons, products);

            PrintPersons(persons);

        }
        
        private static void InitializePersons(string[] personNameMoneyPair, List<Person> persons)
        {
            foreach (var pair in personNameMoneyPair)
            {
                string[] personArguments = pair.Split("=");
                string name = personArguments[0];
                decimal money = decimal.Parse(personArguments[1]);

                Person person = new Person(name, money);
                persons.Add(person);
            }
        }

        private static void InitializeProducts(string[] productNameCostPair, List<Product> products)
        {
            foreach (var pair in productNameCostPair)
            {
                string[] productArguments = pair.Split("=");
                string name = productArguments[0];
                decimal cost = decimal.Parse(productArguments[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
        }
        private static void BuyProducts(List<Person> persons, List<Product> products)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = commandArguments[0];
                string productName = commandArguments[1];

                Person person = persons.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                if (product is not null && person is not null)
                {
                    Console.WriteLine(person.Buy(product));
                }
            }
        }

        private static void PrintPersons(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}