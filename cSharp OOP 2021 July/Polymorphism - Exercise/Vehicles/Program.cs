using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), int.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), int.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), int.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                string vehicle = commands[1];
                double amount = double.Parse(commands[2]);

                if (command == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(amount));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(amount));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(amount));
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(amount);
                    }
                    else
                    {
                        bus.Refuel(amount);
                    }
                }
                else
                {
                    Console.WriteLine(bus.DriveEmpty(amount));
                }                
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }
    }
}
