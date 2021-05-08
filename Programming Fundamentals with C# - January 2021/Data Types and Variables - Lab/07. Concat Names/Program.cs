using System;
using System.Linq;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            string char1 = Console.ReadLine();
            string char2 = Console.ReadLine();
            string char3 = Console.ReadLine();

            Console.WriteLine($"{char1}{char3}{char2}");
        }
    }
}
