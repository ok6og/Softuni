using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        const double Aircondition = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {           
        }
        public override double FuelConsumption => base.FuelConsumption + Aircondition;
    }
}
