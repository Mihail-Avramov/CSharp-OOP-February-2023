using System;
using System.Collections.Generic;

using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;
        private readonly ICollection<IAnimal> animals;

        private Engine()
        {
            this.animals = new List<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer, IFoodFactory foodFactory, IAnimalFactory animalFactory)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }

        public void Run()
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                try
                {
                    IAnimal animal = animalFactory.Create(input);
                    animals.Add(animal);

                    input = reader.ReadLine();
                    IFood food = foodFactory.Create(input);

                    writer.WriteLine(animal.ProduceSound());

                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }

        }
    }
}
