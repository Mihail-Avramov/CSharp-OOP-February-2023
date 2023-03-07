using System;
using System.Collections.Generic;
using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

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
            List<IBirthable> birthables = new List<IBirthable>();

            AddCitizensAndPets(birthables);

            string year = reader.ReadLine();

            PrintResult(birthables, year);
        }

        private void AddCitizensAndPets(List<IBirthable> birthables)
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] commandArguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = commandArguments[0];

                if (type == "Citizen")
                {
                    IBirthable citizen = new Citizen(commandArguments[1], int.Parse(commandArguments[2]),
                        commandArguments[3], commandArguments[4]);
                    birthables.Add(citizen);
                }
                else if (type == "Pet")
                {
                    IBirthable pet = new Pet(commandArguments[1], commandArguments[2]);
                    birthables.Add(pet);
                }
            }
        }

        private void PrintResult(List<IBirthable> birthables, string year)
        {

            foreach (var individual in birthables)
            {
                if (individual.Birthdate.EndsWith(year))
                {
                    writer.WriteLine(individual.Birthdate);
                }
            }
        }
    }
}
