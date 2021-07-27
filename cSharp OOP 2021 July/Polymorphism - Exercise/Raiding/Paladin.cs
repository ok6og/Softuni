using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        const int POWER = 100;
        public Paladin(string name) : base(name)
        {
        }

        public override int Power => POWER;
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {POWER}";
        }
    }
}
