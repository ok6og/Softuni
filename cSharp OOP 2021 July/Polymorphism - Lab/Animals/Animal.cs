﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;

        private string favouriteFood;

        public Animal(string name, string food)
        {
            this.name = name;
            this.favouriteFood = food;
        }

        public virtual  void ExplainSelf()
        {
            Console.WriteLine($"I am {name} and my favourite food is {favouriteFood}");
        }
          
    }
}
