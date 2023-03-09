using System;
using System.Collections.Generic;

using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public const double CatWeightMultiplier = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier
            => CatWeightMultiplier;

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        public override string ProduceSound()
            => "Meow";
    }
}
