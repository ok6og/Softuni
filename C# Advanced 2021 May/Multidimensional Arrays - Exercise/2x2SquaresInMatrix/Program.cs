using System;
using System.Linq;

namespace _2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int counter = 0;
            char[,] matrix = new char[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                char[] arr = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            for (int row = 0; row < size[0]-1; row++)
            {
                for (int col = 0; col < size[1]-1; col++)
                {
                    if(matrix[row,col] == matrix[row,col+1] &&
                        matrix[row,col] == matrix[row+1,col]&&
                        matrix[row,col] == matrix[row+1,col+1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
