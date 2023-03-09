using System;

using WildFarm.Factories.Interfaces;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood Create(string food)
        {
            string[] foodArguments = food.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodArguments[0];
            int foodAmount = int.Parse(foodArguments[1]);

            switch (foodType)
            {
                case "Fruit":
                    return new Fruit(foodAmount);
                case "Meat":
                    return new Meat(foodAmount);
                case "Seeds":
                    return new Seeds(foodAmount);
                case "Vegetable":
                    return new Vegetable(foodAmount);
                default:
                    throw new ArgumentException("Invalid food type");
            }
        }
    }
}
