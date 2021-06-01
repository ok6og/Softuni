using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesBox = new Stack<int>( Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int rackCapacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 1;

            while (clothesBox.Any())
            {
                sum += clothesBox.Peek();

                if(sum <= rackCapacity)
                {
                    clothesBox.Pop();
                }
                else
                {
                    sum = 0;
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
