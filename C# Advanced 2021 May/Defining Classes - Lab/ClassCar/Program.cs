using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myCar = new Car();

            myCar.Make = "Volkswagen";
            myCar.Model = "Golf 5";
            myCar.Year = 2007;


        }
    }
}
