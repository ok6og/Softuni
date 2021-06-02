﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<(string name, int age), int, bool> younger = (person, age) => person.age < age;
            Func<(string name, int age), int, bool> older = (person, age) => person.age >= age;

            int n = int.Parse(Console.ReadLine());
            List<(string name, int age)> people = new List<(string name, int age)>();

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add((person[0], int.Parse(person[1])));
            }

            string condition = Console.ReadLine();
            int filter = int.Parse(Console.ReadLine());
            string[] visual = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            switch (condition)
            {
                case "younger":
                    people = people
                        .Where(p => younger(p, filter))
                        .ToList();
                    break;
                case "older":
                    people = people
                        .Where(p => older(p, filter))
                        .ToList();
                    break;
            }

            foreach (var person in people)
            {
                List<string> output = new List<string>();

                if (visual.Contains("name"))
                {
                    output.Add(person.name);
                }

                if (visual.Contains("age"))
                {
                    output.Add(person.age.ToString());
                }
                Console.WriteLine(string.Join(" - ", output ));
            }
        }
    }
}
