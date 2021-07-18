using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private int cost;
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }

        }

        public int Cost
        {
            get => this.cost;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }

        public Product(string name , int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

   
}
