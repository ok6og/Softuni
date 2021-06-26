using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var freshness = new Stack<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));

            Dictionary<string, int> dishes = new Dictionary<string, int>
            {
                {"Dipping sauce", 0},
                {"Green salad", 0 },
                {"Chocolate cake",0 },
                {"Lobster",0 }
            };
            
            
            while (freshness.Count != 0 && ingredients.Count != 0)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int dish = ingredients.Peek() * freshness.Pop();

                if (ingredients.Peek()==0)
                {

                }

                if (dish == 150)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                }
                else if (dish == 250)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                }
                else if (dish == 300)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                }
                else if(dish == 400)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                }
                else
                {
                    int ingredient = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(ingredient);
                }
            }

            int sum = ingredients.Sum();

            if (dishes["Dipping sauce"]>=1 && dishes["Green salad"] >= 1 && dishes["Chocolate cake"] >= 1 && dishes["Lobster"] >= 1)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (sum >= 1)
            {
                Console.WriteLine($"Ingredients left: {sum}");
            }

            var sortedDishes = dishes.OrderBy(x => x.Key);

            foreach (var dish in sortedDishes)
            {
                if (dish.Value != 0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}
