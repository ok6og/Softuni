using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        const int POWER = 100;
        public Warrior(string name) : base(name)
        {
        }

        public override int Power => POWER;
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {POWER} damage";
        }
    }
}
