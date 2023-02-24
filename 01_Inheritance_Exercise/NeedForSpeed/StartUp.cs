using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new(111, 20);

            Console.WriteLine($"Fuel before drive: {sportCar.Fuel} liters");
            Console.WriteLine($"Fuel Consumption: {sportCar.FuelConsumption} liters per km");
            Console.Write($"Enter the distance you want to drive in km: ");
            int distance = int.Parse(Console.ReadLine());
            sportCar.Drive(distance);
            Console.WriteLine($"Fuel left: {sportCar.Fuel} liters");
        }
    }
}
