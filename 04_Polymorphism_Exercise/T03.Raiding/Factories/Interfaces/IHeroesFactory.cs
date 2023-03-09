using Raiding.Models.Interfaces;

namespace Raiding.Factories.Interfaces
{
    public interface IHeroesFactory
    {
        IBaseHero Create(string heroType, string heroName);
    }
}
