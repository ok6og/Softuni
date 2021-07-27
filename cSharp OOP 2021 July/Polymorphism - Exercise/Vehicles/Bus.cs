using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        const double Aircondition = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        public override double FuelConsumption => base.FuelConsumption + Aircondition;
        public string DriveEmpty(double distance)
        {
            if (FuelQuantity > base.FuelConsumption * distance)
            {
                FuelQuantity = FuelQuantity - base.FuelConsumption * distance;
                return $"{GetType().Name} travelled {distance} km";

            }
            return $"{GetType().Name} needs refueling";
        }
    }
}
