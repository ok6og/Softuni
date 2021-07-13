using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public decimal Salary { get; private set; }

        public Person(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }

        public Person(string fName, string lName, int age, decimal salary)
                :this(fName,lName,age)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            decimal increase = percentage;
            if (Age<30)
            {
                increase = percentage / 2;
            }

            Salary += Salary * increase / 100;
            
        }
    }
}
