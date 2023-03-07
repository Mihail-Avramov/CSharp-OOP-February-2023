using System;
using BirthdayCelebrations.IO.Interfaces;

namespace BirthdayCelebrations.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
