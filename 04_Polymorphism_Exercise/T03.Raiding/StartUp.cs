using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroesFactory heroesFactory = new HeroesFactory();

            IEngine engine = new Engine(reader, writer, heroesFactory);

            engine.Run();
        }
    }
}