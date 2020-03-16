using System;
using System.Collections.Generic;
using System.Text;

namespace _200306_Exo03_BossMonster.Objects.Cards
{
    public abstract class AbstractDeck
    {
        protected List<AbstractCard> cards;

        public virtual void AddCard(AbstractCard c)
        {
            cards.Add(c);
        }

        public virtual void AddCards(List<AbstractCard> c)
        {
            cards.AddRange(c);
        }

        public virtual void RemoveTopCard()
        {
            cards.RemoveAt(cards.Count-1);
        }

        public virtual void PutCardUnderDeck(AbstractCard c)
        {
            cards.Insert(0, c);
        }

        public virtual void EmptyDeck() { cards.Clear(); }
    }
}
