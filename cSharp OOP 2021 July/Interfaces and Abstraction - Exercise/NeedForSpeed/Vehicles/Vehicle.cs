using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Vehicles
{
    public class Vehicle
    {
        public double DefaultFuelConsumption { get;} = 1.25;
        public virtual double FuelConsumption { get;private set; }
        public double Fuel { get; set; }
        public int HorsePower { get;private set; }
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual void Drive(double kilometers) => this.Fuel = this.Fuel - kilometers * DefaultFuelConsumption;

    }
}
