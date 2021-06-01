using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }
            int primary = 0;
            int secondary = 0;
            for (int row = 0; row < size; row++)
            {
                primary += matrix[row, row];
                secondary += matrix[row, size - row - 1];
            }

            Console.WriteLine(Math.Abs(primary-secondary));
        }
    }
}
