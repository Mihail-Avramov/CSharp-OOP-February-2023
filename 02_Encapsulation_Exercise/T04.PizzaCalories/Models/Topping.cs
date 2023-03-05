namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;

    public class Topping
    {
        private const double BaseToppingCaloriesPerGram = 2;
        private const double MinToppingWeight = 1.0;
        private const double MaxToppingWeight = 50.0;

        private readonly Dictionary<string, double> toppingTypesCalories;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            toppingTypesCalories= new Dictionary<string, double>()
            {
                { "meat", 1.2 }, 
                { "veggies", 0.8 }, 
                { "cheese", 1.1 }, 
                { "sauce", 0.9 }
            };

            this.Type = type;
            this.Weight = weight;
        }



        public string Type
        {
            get => this.type;
            private set
            {
                if (!toppingTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < MinToppingWeight || value > MaxToppingWeight)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [{MinToppingWeight}..{MaxToppingWeight}].");
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double toppingTypeModifier = toppingTypesCalories[this.Type.ToLower()];

                return BaseToppingCaloriesPerGram * Weight * toppingTypeModifier;
            }
        }

    }
}
