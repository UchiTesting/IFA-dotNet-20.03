using System;
using System.Collections.Generic;
using System.Text;

namespace _200306_Exo03_BossMonster.Objects.Cards
{
    public abstract class AbstractDeck
    {
        protected List<AbstractCard> cards;

        protected virtual void AddCard(AbstractCard c)
        {
            cards.Add(c);
        }

        protected virtual void AddCards(List<AbstractCard> c)
        {
            cards.AddRange(c);
        }

        protected virtual void RemoveTopCard()
        {
            cards.RemoveAt(cards.Count-1);
        }
    }
}
