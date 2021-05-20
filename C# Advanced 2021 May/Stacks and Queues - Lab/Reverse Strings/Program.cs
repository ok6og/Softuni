using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> firstStack = new Stack<char>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                firstStack.Push(input[i]);
            }

            while(firstStack.Count > 0)
            {
                Console.Write(firstStack.Pop());
            }
        }
    }
}
