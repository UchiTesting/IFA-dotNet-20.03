using System;
using System.Collections.Generic;
using System.Text;
using _200306_Exo03_BossMonster.Enums;

namespace _200306_Exo03_BossMonster.Objects.Cards
{
    public class AbstractCard
    {
        protected string Name { get; set; }
        protected EffectTypes effect { get; set; }
    }
}
