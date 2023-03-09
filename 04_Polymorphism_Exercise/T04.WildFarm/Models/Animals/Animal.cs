using System;
using System.Collections.Generic;
using System.Linq;

using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }
        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        public abstract string ProduceSound();


        public void Eat(IFood food)
        {
            if(PreferredFoods.All(pf => pf.Name != food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightMultiplier;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
