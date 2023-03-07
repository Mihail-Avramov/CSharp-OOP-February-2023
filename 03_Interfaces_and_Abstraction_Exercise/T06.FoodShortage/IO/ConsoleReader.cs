using System;
using FoodShortage.IO.Interfaces;

namespace FoodShortage.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
