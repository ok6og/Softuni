using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products
{
    public class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double milimiters)
            : base(name, price, milimiters)
        {
        }
    }
}
