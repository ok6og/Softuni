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
                if(sum+clothesBox.Peek() < rackCapacity)
                {
                    sum += clothesBox.Pop();
                }
                else if(sum+clothesBox.Peek() == rackCapacity)
                {
                    clothesBox.Pop();
                    sum = 0;
                    counter++;
                }
                else if(sum+clothesBox.Peek() > rackCapacity)
                {
                    counter++;
                    sum = 0;
                    sum += clothesBox.Pop();
                }
            }

            Console.WriteLine(counter);
        }
    }
}
