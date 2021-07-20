using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car,IElectricCar
    {
        public int Battery { get; set; }
        public Tesla(int battery, string model, string color)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }       
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
 