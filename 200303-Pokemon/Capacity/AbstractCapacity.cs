using System;
using System.Collections.Generic;
using System.Text;

namespace _200303_Pokemon.Capacity
{
    public abstract class AbstractCapacity
    {
        protected string Name;
        public AbstractCapacity(string name) { Name = name; }

        public abstract void UseCapacity(Pokemon caster, Pokemon target);

        public string IntroduceCapacity()
        {
            return "Casting " + Name;
        }
    }
}
