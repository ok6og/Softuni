using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        const double Aircondition = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption => base.FuelConsumption + Aircondition;
        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (TankCapacity >= FuelQuantity + fuel)
            {
                FuelQuantity = FuelQuantity + (fuel * 0.95);
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
