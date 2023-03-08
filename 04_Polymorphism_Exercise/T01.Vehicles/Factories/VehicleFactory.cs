using System;

using Vehicles.Factories.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption)
        {
            if (type == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                return new Truck(fuelQuantity, fuelConsumption);
            }

            throw new ArgumentException("Invalid vehicle type");
        }
    }
}
