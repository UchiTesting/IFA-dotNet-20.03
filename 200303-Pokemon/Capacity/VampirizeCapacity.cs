using System;
using System.Collections.Generic;
using System.Text;

namespace _200303_Pokemon.Capacity
{
    class VampirizeCapacity : HealCapacity
    {
        public VampirizeCapacity(string name, int healAmount) : base(name, healAmount)
        {
        }
        public VampirizeCapacity(int healAmount = 50) : this("Vampirize", healAmount) { }

        public override void UseCapacity(Pokemon caster, Pokemon target)
        {
            Console.WriteLine(caster +": "+ IntroduceCapacity());
            VampirizeHP(target);
            caster.Pv += HealAmount;
        }
        private void VampirizeHP(Pokemon target)
        {
            int resultHP = target.Pv - HealAmount;
            if (resultHP > 0)
                target.Pv = resultHP;
            else
                target.Pv = 0;
        }
    }
}
