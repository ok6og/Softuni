using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public string FirstName 
        {
            get
            {
                return firstName;
            } 
          
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstName = value;
            } 
        }
        public string LastName
        {
            get
            {
                return lastName;
            }

            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }

            private set
            {
                if (value <1)
                {
                    throw new ArgumentException("Age cannot be zero or negative integer!");
                }
                age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }

            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                salary = value;
            }
        }

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
            return $"{FirstName} {LastName} gets {Salary:F2} leva.";
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
