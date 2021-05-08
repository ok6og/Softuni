using System;
using System.Linq;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            char lol = char.Parse(Console.ReadLine());
            bool result = Char.IsUpper(lol);

            if (result)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
