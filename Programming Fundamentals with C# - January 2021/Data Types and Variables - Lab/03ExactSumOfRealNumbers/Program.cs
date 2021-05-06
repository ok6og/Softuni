using System;
using System.Linq;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < N; i++)
            {
                decimal num = decimal.Parse(Console.ReadLine());
                sum = sum + num;

            }
            Console.WriteLine(sum);

        }
    }
}
