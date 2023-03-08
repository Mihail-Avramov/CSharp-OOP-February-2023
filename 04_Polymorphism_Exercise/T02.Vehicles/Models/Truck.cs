using System;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, FuelConsumptionIncrement)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            base.Refuel(liters * 0.95);
        }
    }
}
