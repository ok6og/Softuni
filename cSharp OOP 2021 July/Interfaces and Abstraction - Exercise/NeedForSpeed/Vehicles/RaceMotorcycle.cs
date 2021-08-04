using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Vehicles
{
    public class RaceMotorcycle : Motorcycle
    {

        public override double FuelConsumption => 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override void Drive(double kilometers) => this.Fuel = this.Fuel - kilometers * FuelConsumption;

    }
}
