using System;

namespace CodeTestProject
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int nCopy = n;
            int sum = 0;

            while (n > 0)
            {
                int factoriel = 1;
                int number = n % 10;
                n /= 10;

                for (int i = 2; i <= number; i++)
                {
                    factoriel *= i;
                }

                sum += factoriel;
            }
            if (sum == nCopy)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}