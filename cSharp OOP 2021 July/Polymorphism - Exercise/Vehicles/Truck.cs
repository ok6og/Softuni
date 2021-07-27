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
            if (FuelQuantity+fuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }
            base.Refuel(fuel * 0.95);
        }
    }
}
