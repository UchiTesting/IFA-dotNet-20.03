using System;
using System.Collections.Generic;
using System.Text;
using _200303_Pokemon.Exceptions;

namespace _200303_Pokemon.Capacity
{
    public class AttackCapacity : AbstractCapacity
    {
        private int AttackAmount;
        public AttackCapacity(string name, int atk) : base(name) { SetAttackAmount(atk); }

        private void SetAttackAmount(int atk)
        {
            bool isPositive = (atk >= 0);
            switch (isPositive)
            {
                case true:
                    bool isIntoLimit = (atk <= 100);
                    switch (isIntoLimit)
                    {
                        case true:
                            AttackAmount = atk;
                            break;
                        case false:
                            AttackAmount = 100;
                            break;
                    }
                    break;
                case false:
                    AttackAmount = 0;
                    break;
            }
        }

        public override void UseCapacity(Pokemon caster, Pokemon target)
        {
            Console.WriteLine(caster +" "+ IntroduceCapacity());

            int atkratio = 1;
            if (caster.CheckStrongerElement(target))
                atkratio = 2;

            if (target.Pv > 0)
                target.Pv -= this.AttackAmount * atkratio;
            else
            {
                throw new CannotRemoveHP_OnDeadEnemyException(string.Format("Enemy {0} is dead.", target.Name));
            }

            if (target.Pv <= 0)
                target.Pv = 0;
        }
    }
}
