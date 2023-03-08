using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionIncrement;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double fuelConsumptionIncrement)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            this.fuelConsumptionIncrement = fuelConsumptionIncrement;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            private set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity{ get; private set; }


        public string Drive(double distance)
        {
            double currentConsumption = FuelConsumption + fuelConsumptionIncrement;

            if (FuelQuantity < distance * currentConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * currentConsumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            double currentConsumption = FuelConsumption;

            if (FuelQuantity < distance * currentConsumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * currentConsumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
