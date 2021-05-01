using System;
using System.Linq;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Concat(username.Reverse());

            bool isLogged = false;
            string inputPass = "";
            int counter = 0;


            while (!isLogged)
            {
                inputPass = Console.ReadLine();
                counter++;
                if (counter == 4)
                {
                    if (inputPass != password)
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                    else if (inputPass == password)
                    {
                        Console.WriteLine($"User {username} logged in.");
                    }
                }
                else
                {
                    Console.WriteLine($"User {username} blocked!");
                }

            }
        }
    }
}
