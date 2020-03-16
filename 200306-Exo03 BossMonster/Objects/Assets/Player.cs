using System;
using System.Collections.Generic;
using System.Text;
using static Simple_IO.AskData;

namespace _200306_Exo03_BossMonster.Objects.Assets
{
    public class Player
    {
        private int number;
        public int Number { get => number; set => number = value; }

        public Player(int number)
        {
            Number = number;
        }
    }
}
