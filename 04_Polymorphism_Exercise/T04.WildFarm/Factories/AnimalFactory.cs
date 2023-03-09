using System;

using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string animal)
        {
            string[] animalArguments = animal.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string animalType = animalArguments[0];
            string animalName = animalArguments[1];
            double animalWeight = double.Parse(animalArguments[2]);

            switch (animalType)
            {
                case "Owl":
                    return new Owl(animalName, animalWeight, double.Parse(animalArguments[3]));
                case "Hen":
                    return new Hen(animalName, animalWeight, double.Parse(animalArguments[3]));
                case "Mouse":
                    return new Mouse(animalName, animalWeight, animalArguments[3]);
                case "Dog":
                    return new Dog(animalName, animalWeight, animalArguments[3]);
                case "Cat":
                    return new Cat(animalName, animalWeight, animalArguments[3], animalArguments[4]);
                case "Tiger":
                    return new Tiger(animalName, animalWeight, animalArguments[3], animalArguments[4]);
                default:
                    throw new ArgumentException("Invalid animal type!");
            }
        }
    }
}
