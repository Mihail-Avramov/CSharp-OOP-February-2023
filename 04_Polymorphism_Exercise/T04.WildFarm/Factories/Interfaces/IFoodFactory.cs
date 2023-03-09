using WildFarm.Models.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        public IFood Create(string foodArguments);
    }
}
