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
        PackOfHeroes BrowsingHeroes; // Heroes in the Dungeon
        PackOfHeroes DeadHeroes; // Heroes defeated
        PackOfHeroes CompletedHeroes; // Heroes who completed the dungeon.s

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
            else
                CompactDungeon();
        }

        private void CompactDungeon()
        {
            bool Deck1HasCards = Deck1.GetRoomsStackedNumber() > 0;
            bool Deck2HasCards = Deck2.GetRoomsStackedNumber() > 0;
            bool Deck3HasCards = Deck3.GetRoomsStackedNumber() > 0;
            bool Deck4HasCards = Deck4.GetRoomsStackedNumber() > 0;

            if (Deck3HasCards && !Deck4HasCards)
                MoveDeck(Deck3, Deck4);

            if (Deck2HasCards && !Deck3HasCards)
                MoveDeck(Deck2, Deck3);

            if (Deck1HasCards && !Deck2HasCards)
                MoveDeck(Deck1, Deck2);
        }

        private void MoveDeck(RoomDeck source, RoomDeck destination)
        {
            if (destination.GetRoomsStackedNumber() < 1)
            {
                destination = source;
                source.EmptyDeck();
                CompactDungeon();
            }
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
