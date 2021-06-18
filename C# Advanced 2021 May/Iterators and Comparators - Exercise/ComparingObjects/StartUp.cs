using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string command = String.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split();              
                persons.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));

            }
            int index = int.Parse(Console.ReadLine())-1;
            int equal = 0;
            int notEqual = 0;

            foreach (Person person in persons)
            {
                if (persons[index].CompareTo(person)==0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }
            if (equal <=1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {persons.Count}");
            }
        }
    }
}
