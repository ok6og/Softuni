using System;

namespace 1_Student_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string age = "";
            string grade = "";
            for (int i = 0; i < 3; i++)
            {
                name = Console.ReadLine();
                age = Console.ReadLine();
                grade = Console.ReadLine();
                Console.Write($"Name: {name}, Age: {age}, Grade: {grade}");
            }
        }
    }
}
