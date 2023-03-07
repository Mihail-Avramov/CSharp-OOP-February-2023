using System;
using BorderControl.IO.Interfaces;

namespace BorderControl.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text) => Console.WriteLine(text);

        public void Write(string text) => Console.Write(text);
    }
}
