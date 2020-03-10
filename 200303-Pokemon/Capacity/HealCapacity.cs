using System;
using System.Collections.Generic;
using System.Text;

namespace _200303_Pokemon.Capacity
{
    public class HealCapacity : AbstractCapacity
    {
        protected int HealAmount;
        public HealCapacity(string name, int healAmount) : base(name) { SetHealAmount(healAmount); }

        public HealCapacity(int healAmount = 10) : this("Heal", healAmount){ }

        public override void UseCapacity(Pokemon caster, Pokemon target)
        {
            Console.WriteLine(caster + IntroduceCapacity());

            caster.Pv += HealAmount;
        }

        public void SetHealAmount(int ha)
        {
            bool isPositive = (ha >= 0);
            switch (isPositive)
            {
                case true:
                    bool isIntoLimit = (ha <= 100);
                    switch (isIntoLimit)
                    {
                        case true:
                            HealAmount = ha;
                            break;
                        case false:
                            HealAmount = 100;
                            break;
                    }
                    break;
                case false:
                    HealAmount = 0;
                    break;
            }
        }
    }
}
