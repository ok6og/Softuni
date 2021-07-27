using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set 
            {
                if (TankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }

            }
        }

        public virtual double FuelConsumption { get;}
        public int TankCapacity { get;protected set; }

        public Vehicle(double fuelQuantity, double fuelConsumption , int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;

        }
        public string Drive(double distance)
        {
            if (FuelQuantity > FuelConsumption * distance)
            {
                FuelQuantity = FuelQuantity - FuelConsumption * distance;
                return $"{GetType().Name} travelled {distance} km";

            }
            return $"{GetType().Name} needs refueling";
        }

        

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if(TankCapacity >= FuelQuantity + fuel)
            {
                FuelQuantity += fuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
