using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] persons = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            var people = new List<Person>();
            var producte = new List<Product>();
            
            try
            {
                for (int i = 0; i < persons.Length; i++)
                {
                    string[] person = persons[i].Split('=');
                    Person person1 = new Person(person[0], int.Parse(person[1]));
                    people.Add(person1);
                }

                for (int i = 0; i < products.Length; i++)
                {
                    string[] product = products[i].Split('=');
                    Product product1 = new Product(product[0], int.Parse(product[1]));
                    producte.Add(product1);
                }

                string command = default;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] buy = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string personName = buy[0];
                    int nameMoney = people.First(x => x.Name == personName).Money;
                    string productName = buy[1];
                    int productCost = producte.First(x => x.Name == productName).Cost;
                    
                    if (nameMoney - productCost < 0)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        people.First(x => x.Name == personName).Money -= productCost;
                        Console.WriteLine($"{personName} bought {productName}");
                        people.First(x => x.Name == personName).AddProduct(producte.First(x => x.Name == productName));
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Person.Print(people);        
        }
    }
}
