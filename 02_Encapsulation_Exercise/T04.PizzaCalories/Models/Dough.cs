namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const double BaseDoughCaloriesPerGram = 2;
        private const double MinDoughWeight = 1.0;
        private const double MaxDoughWeight = 200.0;
        private readonly Dictionary<string, double> flourTypesCalories;
        private readonly Dictionary<string, double> bakingTechniquesCalories;


        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.flourTypesCalories = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
            this.bakingTechniquesCalories = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!this.flourTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!bakingTechniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < MinDoughWeight || value > MaxDoughWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinDoughWeight}..{MaxDoughWeight}].");
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double flourTypeModifier = bakingTechniquesCalories[BakingTechnique];
                double techniqueModifier = flourTypesCalories[FlourType];

                return BaseDoughCaloriesPerGram * weight * flourTypeModifier * techniqueModifier;
            }
        }

    }
}
