using System;
using System.Linq;

namespace _3x3MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            int maxSum = 0;
            int row1 = 0;
            int col1 = 0;
            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    if (matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + 
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + 
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2] > maxSum)
                    {
                        maxSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + 
                            matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + 
                            matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                        row1 = row;
                        col1 = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = row1; row <= row1+2; row++)
            {
                
                for (int col = col1; col <= col1+2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
