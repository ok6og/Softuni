using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get;protected set; }
        public double FuelConsumption { get; protected set; }
      
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
            FuelQuantity += fuel;
        }
    }
}
