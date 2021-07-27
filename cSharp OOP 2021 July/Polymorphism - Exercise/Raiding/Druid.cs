using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        const int POWER = 80;
        public Druid(string name) : base(name)
        {
        }

        public override int Power => POWER;
        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {POWER}";
        }
    }
}
