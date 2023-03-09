using System;
using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding.Factories
{
    public class HeroesFactory : IHeroesFactory
    {
        public IBaseHero Create(string heroType, string heroName)
        {
            switch (heroType)
            {
                case "Druid":
                    return new Druid(heroName);
                case "Paladin":
                    return new Paladin(heroName);
                case "Rogue":
                    return new Rogue(heroName);
                case "Warrior":
                    return new Warrior(heroName);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
