﻿using System;
using System.Linq;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());

            decimal kilometers = meters / 1000M;


            Console.WriteLine($"{kilometers:F2}");

        }
    }
}
