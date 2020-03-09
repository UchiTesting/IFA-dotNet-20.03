using System;
using System.Collections.Generic;
using System.Text;
using _200306_Exo03_BossMonster.Objects.Cards;

namespace _200306_Exo03_BossMonster.Objects.Assets
{
    public class Town
    {
        PackOfHeroes heroes;
        private string Name;
        public Town(string name) { Name = name; heroes = new PackOfHeroes(); }


    }
}
