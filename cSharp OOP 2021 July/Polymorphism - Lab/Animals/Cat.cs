using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string food) : base(name, food)
        {
        }
        public override void ExplainSelf()
        {
            base.ExplainSelf();
            Console.WriteLine("MEEOW");
        }
    }
}
