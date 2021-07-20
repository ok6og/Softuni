using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : Car
    {

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }        
        public override string ToString()
        {
            return $"{Color} Seat {Model}";
        }
    }
}
