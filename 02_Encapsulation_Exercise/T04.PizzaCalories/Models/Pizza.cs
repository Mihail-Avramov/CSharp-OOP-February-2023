namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Pizza
    {
        private const int MaxToppingsCount = 10;
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;
        
        private readonly List<Topping> toppings;
        private string name;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.toppings = new List<Topping>();
        }


        public string Name
        {
            get => this.name;
            set
            {
                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException(
                        $"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; private set; }

        public double Calories => Dough.Calories + toppings.Sum(t => t.Calories);

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == MaxToppingsCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxToppingsCount}].");
            }

            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:f2} Calories.";
        }
    }
}
