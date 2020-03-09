using System;
using System.Collections.Generic;
using System.Text;
using _200306_Exo03_BossMonster.Objects.Cards;

namespace _200306_Exo03_BossMonster.Objects.Assets
{
    public class PackOfHeroes
    {
        List<HeroCard> heroes;
        public PackOfHeroes()
        {
            heroes = new List<HeroCard>();
        }

        public void AddHero(HeroCard h) { heroes.Add(h); }

        public void RemoveHero(int idx) { heroes.RemoveAt(idx); }
        public void RemoveHero(HeroCard h)
        {
            HeroCard tmpHero = heroes.Find(hero => hero == h);
            if (tmpHero != null)
                heroes.Remove(tmpHero);
        }

        // Create a method that computes the total atk or number of heroes in order to count the scores
    }
}
