using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();
            Stack<string> calculus = new Stack<string>(input);

            while (calculus.Count > 1)
            {
                int x = int.Parse(calculus.Pop());
                string oper = calculus.Pop();
                int y = int.Parse(calculus.Pop());
               
                if(oper == "+")
                {
                    calculus.Push((x + y).ToString());
                }
                else
                {
                    calculus.Push((x - y).ToString());
                }
            }

            Console.WriteLine(calculus.Peek());

        }
    }
}
