using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> que = new Queue<int>();

            for (int i = 0; i < commands[0]; i++)
            {
                que.Enqueue(numbers[i]);
            }

            for (int i = 0; i < commands[1]; i++)
            {
                que.Dequeue();
            }

            if (que.Contains(commands[2]))
            {
                Console.WriteLine("true");
            }
            else if(que.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(que.Min());
            }
        }
    }
}
