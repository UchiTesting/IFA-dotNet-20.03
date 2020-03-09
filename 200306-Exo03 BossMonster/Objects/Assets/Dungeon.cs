using System;
using System.Collections.Generic;
using System.Text;
using _200306_Exo03_BossMonster.Objects.Cards;
using _200306_Exo03_BossMonster.Enums;
using _200306_Exo03_BossMonster.Exceptions;

namespace _200306_Exo03_BossMonster.Objects.Assets
{
    public class Dungeon
    {
        // Deck1 is the leftmost deck, Deck4 is the Rightmost deck just next to the boss card.
        protected RoomDeck Deck1;
        protected RoomDeck Deck2;
        protected RoomDeck Deck3;
        protected RoomDeck Deck4;
        protected BossCard Boss;
        PackOfHeroes DeadHeroes;
        PackOfHeroes CompletedHeroes;

        public Dungeon(BossCard boss)
        {
            Deck1 = new RoomDeck();
            Deck2 = new RoomDeck();
            Deck3 = new RoomDeck();
            Deck4 = new RoomDeck();
            SetBossCard(boss);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="deckNumber"></param>
        public void StackCard(RoomCard c, DeckNumber deckNumber)
        {
            RoomDeck tmpDeck = Deck4;

            switch (deckNumber)
            {
                case DeckNumber.FIRST:
                    tmpDeck = Deck1;
                    break;
                case DeckNumber.SECOND:
                    tmpDeck = Deck2;
                    break;
                case DeckNumber.THIRD:
                    tmpDeck = Deck3;
                    break;
                case DeckNumber.FOURTH:
                    tmpDeck = Deck4;
                    break;
            }

            if (CheckRightDeckInitiated(deckNumber))
                tmpDeck.AddCard(c);
            else throw new DeckEmptyException("The deck on the right cannot be empty before you stack a card on the current one.");
        }

        public bool CheckRightDeckInitiated(DeckNumber deckNumber)
        {
            if (deckNumber == DeckNumber.FIRST && Deck2.GetRoomsStackedNumber() < 1)
                return false;

            if (deckNumber == DeckNumber.SECOND && Deck2.GetRoomsStackedNumber() < 1)
                return false;

            if (deckNumber == DeckNumber.THIRD && Deck4.GetRoomsStackedNumber() < 1)
                return false;

            // The rightmost Deck needs no check and a return value true to be OK with ActualStackCard code.
            return true;
        }

        public void SetBossCard(BossCard b) { Boss = b; }
    }
}
