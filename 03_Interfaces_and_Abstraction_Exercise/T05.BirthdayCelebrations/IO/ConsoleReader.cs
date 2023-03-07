using System;
using BirthdayCelebrations.IO.Interfaces;

namespace BirthdayCelebrations.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
