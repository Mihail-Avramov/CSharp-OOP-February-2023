using System;
using System.Xml;
using PizzaCalories.Models;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaArguments = Console.ReadLine().Split();
                string[] doughArguments = Console.ReadLine().Split();

                string pizzaName = pizzaArguments[1];

                Dough dough = new(doughArguments[1], doughArguments[2], double.Parse(doughArguments[3]));

                Pizza pizza = new(pizzaName, dough);

                while (true)
                {
                    string toppingsInput = Console.ReadLine();

                    if (toppingsInput == "END")
                    {
                        break;
                    }

                    string[] toppingsTokens = toppingsInput.Split();

                    Topping topping = new(toppingsTokens[1], double.Parse(toppingsTokens[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}