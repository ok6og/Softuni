using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        const double Aircondition = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + Aircondition;
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity = FuelQuantity + (fuel*0.95);
        }
    }
}
