using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Core.Interface;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    internal class Engine: IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;
        private readonly ICollection<IVehicle> vehicles;


        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            try
            {
                vehicles.Add(CreateIVehicle());
                vehicles.Add(CreateIVehicle());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            int commandCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                try
                {
                    CommandsProcess();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private IVehicle CreateIVehicle()
        {
            string[] vehicleArguments = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return vehicleFactory.Create(vehicleArguments[0], double.Parse(vehicleArguments[1]), double.Parse(vehicleArguments[2]));
        }

        private void CommandsProcess()
        {
            string[] commandArguments = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandArguments[0];
            string iVehicleType = commandArguments[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == iVehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandArguments[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double fuelAmount = double.Parse(commandArguments[2]);
                vehicle.Refuel(fuelAmount);
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }
        }

    }
}
