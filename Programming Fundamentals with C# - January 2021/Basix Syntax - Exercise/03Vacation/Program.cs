using System;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string weekDay = Console.ReadLine();
            double price = 0;

            if (weekDay == "Friday")
            {
                switch (typeGroup)
                {
                    case "Students":
                        price = 8.45;
                        break;
                    case "Business":
                        price = 10.9;
                        break;
                    case "Regular":
                        price = 15;
                        break;
                }
            }
            else if (weekDay == "Saturday")
            {
                switch (typeGroup)
                {
                    case "Students":
                        price = 9.8;
                        break;
                    case "Business":
                        price = 15.6;
                        break;
                    case "Regular":
                        price = 20;
                        break;
                }

            }
            else if (weekDay == "Sunday")
            {
                switch (typeGroup)
                {
                    case "Students":
                        price = 10.46;
                        break;
                    case "Business":
                        price = 16;
                        break;
                    case "Regular":
                        price = 22.5;
                        break;
                }

            }



            if (typeGroup == "Students" && people >= 30)
            {
                price *= 0.85;
            }
            else if (typeGroup == "Business" && people >= 100)
            {
                people = people - 10;
            }
            else if (typeGroup == "Regular" && people >= 10 && people <= 20)
            {
                price *= 0.95;
            }



            double wholePrice = price * people;

            Console.WriteLine($"Total price: {wholePrice:F2}");


        }
    }
}