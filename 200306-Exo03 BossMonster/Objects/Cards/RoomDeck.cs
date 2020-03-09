using System;
using System.Collections.Generic;
using System.Text;
using _200306_Exo03_BossMonster.Exceptions;

namespace _200306_Exo03_BossMonster.Objects.Cards
{
    public class RoomDeck : AbstractDeck
    {
        protected new List<RoomCard> cards;

        public RoomDeck()
        {
            cards = new List<RoomCard>();
        }

        public void AddCard(RoomCard c)
        {
            cards.Add(c);
        }

        public void AddCards(List<RoomCard> c)
        {
            cards.AddRange(c);
        }
        /// <summary>
        /// Removes the last card of the deck which is the one on top.
        /// Used to destroy a room.
        /// </summary>
        public void DestroyTopRoom()
        {
            if (cards.Count > 0) cards.RemoveAt(cards.Count - 1);
            else throw new DeckEmptyException("Cannot remove a card from an empty deck.");
        }

        public int GetRoomsStackedNumber() { return cards.Count; }
    }
}
