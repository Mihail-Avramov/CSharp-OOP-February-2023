using Telephony.Models.Interfaces;

namespace Telephony.Core
{
    using System;

    using Interfaces;
    using IO.Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] phoneNumbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urlAddresses = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable callable;

            foreach (var number in phoneNumbers)
            {
                if (number.Length == 7)
                {
                    callable = new StationaryPhone();
                }
                else
                {
                    callable = new Smartphone();
                }

                try
                {
                    writer.WriteLine(callable.Call(number));
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }


            }

            IBrowsable browsable = new Smartphone();

            foreach (var url in urlAddresses)
            {
                try
                {
                    writer.WriteLine(browsable.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }
        }
    }
}
