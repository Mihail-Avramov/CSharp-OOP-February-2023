using System;
using System.Collections.Generic;
using System.Linq;
using FoodShortage.Core.Interfaces;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;


namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }


        public void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int buyersCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < buyersCount; i++)
            {
                string[] commandArguments = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArguments.Length == 4)
                {
                    IBuyer citizen = new Citizen(commandArguments[0], int.Parse(commandArguments[1]),
                        commandArguments[2], commandArguments[3]);

                    buyers.Add(citizen);
                }
                else
                {
                    IBuyer rebel = new Rebel(commandArguments[0], int.Parse(commandArguments[1]), commandArguments[2]);

                    buyers.Add(rebel);
                }
            }

            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == input);

                if (buyer is not null)
                {
                    buyer.BuyFood();
                }
            }

            writer.WriteLine(buyers.Sum(b => b.Food).ToString());
        }
    }
}
