using System;
using System.Linq;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            int centureis = int.Parse(Console.ReadLine());
            int years = centureis * 100;
            int days = (int)Math.Truncate(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine($"{centureis} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");


        }
    }
}