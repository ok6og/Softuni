using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Vehicles
{
    public class SportCar : Car
    {
        public override double FuelConsumption => 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
