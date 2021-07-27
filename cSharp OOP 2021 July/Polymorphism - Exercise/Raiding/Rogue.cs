using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        const int POWER = 80;
        public Rogue(string name) : base(name)
        {
        }

        public override int Power => POWER;
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {POWER} damage";
        }
    }
}
