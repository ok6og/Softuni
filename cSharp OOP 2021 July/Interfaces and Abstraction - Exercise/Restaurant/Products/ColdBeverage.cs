using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products
{
    public class ColdBeverage : Beverage
    {
        public ColdBeverage(string name, decimal price, double milimiters) 
            : base(name, price, milimiters)
        {
        }
    }
}
