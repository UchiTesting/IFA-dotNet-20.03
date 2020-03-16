using System;
using System.Collections.Generic;
using System.Text;
using static Simple_IO.AskData;
using _200306_Exo03_BossMonster.Enums;
using _200306_Exo03_BossMonster.Exceptions;
using _200306_Exo03_BossMonster.Objects.Assets;
using _200306_Exo03_BossMonster.Objects.Cards;

namespace _200306_Exo03_BossMonster.Objects.Assets
{
    public class Engine
    {
        int NbPlayers;
        List<Dungeon> dungeons;
        List<Player> players;
        private static Engine instance;
        List<SpellCard> spellCards;
        List<BossCard> bossCards;
        List<HeroCard> heroCards;
        List<RoomCard> roomCards;

        protected Engine()
        {
            NbPlayers = askInt("How many players would you like?: ");

            InitDecks();

            players = new List<Player>();
            dungeons = new List<Dungeon>();

            for (int i = 0; i < NbPlayers; i++)
            {
                players.Add(new Player(i + 1));

                dungeons.Add(new Dungeon());
            }
        }

        private void InitDecks()
        {
            bossCards = new List<BossCard>();
            heroCards = new List<HeroCard>();
            spellCards = new List<SpellCard>();
            roomCards = new List<RoomCard>();

            /// Temporary code to be replaced by any solution that reads from a datasource / file.

            bossCards.Add(new BossCard());
            bossCards.Add(new BossCard());
            bossCards.Add(new BossCard());

            heroCards.Add(new HeroCard());
            heroCards.Add(new HeroCard());
            heroCards.Add(new HeroCard());

            spellCards.Add(new SpellCard());
            spellCards.Add(new SpellCard());
            spellCards.Add(new SpellCard());

            roomCards.Add(new RoomCard());
            roomCards.Add(new RoomCard());
            roomCards.Add(new RoomCard());


        }

        public static Engine GetInstance()
        {
            if (instance == null) {
                return new Engine();
            }

            return instance;
        }


 

    }
}
