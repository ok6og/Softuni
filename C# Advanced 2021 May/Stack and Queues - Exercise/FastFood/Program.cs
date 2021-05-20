using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersQuantity = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(ordersQuantity);

            int count = orders.Count();

            Console.WriteLine(orders.Max());

            for (int i = 0; i < count; i++)
            {
                if (foodQuantity >= orders.Peek())
                {
                    foodQuantity = foodQuantity - orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
