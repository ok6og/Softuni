using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products
{
    public class Beverage : Product
    {
        public virtual double Milliliters { get; set; }
        public Beverage(string name, decimal price, double milimiters) : base(name, price)
        {
            this.Milliliters = milimiters;
        }
    }
}
