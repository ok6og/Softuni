using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];

            for (int row = 0; row < n; row++)
            {
                jagged[row] = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
            }
            string command = Console.ReadLine()?.ToUpper();

            while (command.ToUpper() != "END")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row < 0|| row>=n|| col<0||col>=jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine()?.ToUpper();
                    continue;
                }
                switch (tokens[0])
                {
                    case "ADD":
                        jagged[row][col] += value;;
                        break;
                    case "SUBTRACT":
                        jagged[row][col] -= value;
                        break;
                }
                command = Console.ReadLine()?.ToUpper();
            }

            foreach (int[] array in jagged)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
