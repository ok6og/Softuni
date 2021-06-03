using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvenOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {


           

            int[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string oddOrEven = Console.ReadLine();

         
            var result = new List<int>();
            Predicate<int> even = oddOrEven == "odd"
                ? number => number%2!=0
                : new Predicate<int> (number => number % 2 == 0);




            for (int i = tokens[0]; i <= tokens[1]; i++)
            {
                if(even(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
