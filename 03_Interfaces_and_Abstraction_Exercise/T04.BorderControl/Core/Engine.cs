using System;
using System.Collections.Generic;
using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            List<IIdentifiable> individuals = new List<IIdentifiable>();

            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] commandArguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArguments.Length == 3)
                {
                    IIdentifiable citizen = new Citizen(commandArguments[0], int.Parse(commandArguments[1]), commandArguments[2]);
                    individuals.Add(citizen);
                }
                else
                {
                    IIdentifiable robot = new Robot(commandArguments[0], commandArguments[1]);
                    individuals.Add(robot);
                }
            }

            string invalidIdNumbers = reader.ReadLine();

            foreach (var individual in individuals)
            {
                if (individual.Id.EndsWith(invalidIdNumbers))
                {
                    writer.WriteLine(individual.Id);
                }
            }
        }
    }
}
