using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroesFactory heroesFactory;
        private readonly ICollection<IBaseHero> heroes;

        public Engine(IReader reader, IWriter writer, IHeroesFactory heroesFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroesFactory = heroesFactory;
            this.heroes = new List<IBaseHero>();
        }
        
        public void Run()
        {
            int heroesCount = int.Parse(reader.ReadLine());

            while(heroes.Count < heroesCount)
            {
                try
                {
                    CreateHero();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            int allHeroesPower = heroes.Sum(h => h.Power);

            if (allHeroesPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }

        private void CreateHero()
        {
            string heroName = reader.ReadLine();
            string heroType = reader.ReadLine();

            IBaseHero newBaseHero = heroesFactory.Create(heroType, heroName);

            heroes.Add(newBaseHero);
        }
    }
}
