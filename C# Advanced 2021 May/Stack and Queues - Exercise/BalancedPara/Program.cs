using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedPara
{
    class Program
    {
        static void Main(string[] args)
        {
            string para = Console.ReadLine();
            int half = para.Length / 2;

            Stack<char> paraStack = new Stack<char>(para.Substring(half));
            Queue<char> paraQueue = new Queue<char>(para.Substring(0, half));

            Console.WriteLine(paraStack.Pop());
            Console.WriteLine(paraQueue.Dequeue());

            Console.WriteLine(string.Join(" ", paraStack));
            Console.WriteLine(string.Join(" ", paraQueue));


        }
    }
}
