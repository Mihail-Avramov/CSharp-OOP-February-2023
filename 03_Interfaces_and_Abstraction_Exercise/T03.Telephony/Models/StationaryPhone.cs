namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Interfaces;

    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}
