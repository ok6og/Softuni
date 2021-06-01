using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string token1 = "";
            int token2 = 0;

            Stack<int> elements = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                token1 = Convert.ToString(tokens[0]);

                switch (token1)
                {
                    case "1":
                        elements.Push(tokens[1]);
                        break;
                    case "2":
                        if (elements.Any())
                        {
                            elements.Pop();
                        }
                        break;
                    case "3":
                        if (elements.Any())
                        {
                            Console.WriteLine(elements.Max());
                        }
                        break;
                    case "4":
                        if (elements.Any())
                        {
                            Console.WriteLine(elements.Min());
                        }
                        break;

                }

            }

            Console.WriteLine(string.Join(", ", elements));
 

        }
    }
}
