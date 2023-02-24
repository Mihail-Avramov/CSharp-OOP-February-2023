using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Misho", 101);
            Console.WriteLine(elf.ToString());
        }
    }
}