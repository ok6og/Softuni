using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        const int POWER = default;
        public string Name { get;private set; }
        public virtual int Power { get; private set; }

        public BaseHero(string name)
        {
            this.Name = name;
            this.Power = POWER;
        }

        public virtual string CastAbility()
        {
            return "No hero is BaseHero";
        }
    }
}
