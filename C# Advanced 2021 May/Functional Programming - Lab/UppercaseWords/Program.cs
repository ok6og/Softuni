using System;
using System.Linq;

namespace UppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate = str => str[0] == str.ToUpper()[0];

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => predicate(x))
                .ToList()
                .ForEach(x => Console.WriteLine(x));

           
        }
    }
}
