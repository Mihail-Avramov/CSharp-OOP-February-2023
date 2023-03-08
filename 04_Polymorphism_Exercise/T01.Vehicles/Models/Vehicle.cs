using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double fuelConsumptionIncrement)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + fuelConsumptionIncrement;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }


        public string Drive(double distance)
        {
            if (FuelQuantity < distance * FuelConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * FuelConsumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters) => FuelQuantity += liters;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
