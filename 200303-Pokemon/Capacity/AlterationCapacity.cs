using System;
using System.Collections.Generic;
using System.Text;
using _200303_Pokemon.Enums;

namespace _200303_Pokemon.Capacity
{
    public class AlterationCapacity : AbstractCapacity
    {
        PokemonAlterationEnum Alteration;
        public AlterationCapacity(string name, PokemonAlterationEnum alteration) : base(name) { }
        public override void UseCapacity(Pokemon caster, Pokemon target)
        {
            Console.WriteLine(caster+": " + IntroduceCapacity());
            target.SetAlteration(Alteration);
        }
    }
}
