using System;
using FoodShortage.IO.Interfaces;

namespace FoodShortage.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
