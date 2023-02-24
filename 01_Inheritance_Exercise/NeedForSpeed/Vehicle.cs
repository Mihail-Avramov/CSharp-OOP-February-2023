using System;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get; private set; }
        public double Fuel { get; private set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            double FuelConsumed = kilometers * FuelConsumption;

            if (FuelConsumed <= Fuel)
            {
                Fuel -= FuelConsumed;
            }
            else
            {
                Console.WriteLine("Not enough fuel");
            }
        }

    }
}
