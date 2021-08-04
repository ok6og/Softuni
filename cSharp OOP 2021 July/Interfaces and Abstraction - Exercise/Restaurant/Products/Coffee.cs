using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Products
{
    public class Coffee : HotBeverage
    {
        private const double coffeeMilliliters = 50;
        private const decimal coffeePrice = 3.50M;
        public Coffee(string name, double caffeine) : base(name, 0, 0)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; private set; }

        public override double Milliliters  => coffeeMilliliters;

        public override decimal Price => coffeePrice;
        
    }
}
