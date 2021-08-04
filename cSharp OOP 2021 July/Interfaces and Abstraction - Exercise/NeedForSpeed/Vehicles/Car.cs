using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Vehicles
{
    public class Car : Vehicle
    {
        public override double FuelConsumption => 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override void Drive(double kilometers) => this.Fuel = this.Fuel - kilometers * FuelConsumption;

    }
}
