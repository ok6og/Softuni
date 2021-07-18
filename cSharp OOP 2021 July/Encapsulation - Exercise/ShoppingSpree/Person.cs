using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private readonly List<Product> bagOfProducts;

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


        public int Money
        {
            get => this.money;
            set 
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value; 
            }
        }




       

        public void AddProduct(Product product) => this.bagOfProducts.Add(product);

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public static void Print(List<Person> people)
        {
            foreach (var human in people)
            {
                if (human.bagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{human.Name} - Nothing bought");
                }
                else
                {
                    Console.Write($"{human.Name} - ");
                    Console.WriteLine(string.Join(", ", human.bagOfProducts));
                }
            }
        }

        public override string ToString()
        {
            return base.ToString(); 
        }

    }
}
