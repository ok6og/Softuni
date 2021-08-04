using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products
{
    public class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double milimiters) 
            : base(name, price, milimiters)
        {
        }
    }
}
