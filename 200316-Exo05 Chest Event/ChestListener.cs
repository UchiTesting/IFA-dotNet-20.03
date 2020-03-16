﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _200316_Exo05_Chest_Event
{
    public class ChestListener
    {
        Chest chest;

        public ChestListener(Chest _chest)
        {
            chest = _chest;
            chest.foundCodeEvent += OnFoundCodeEvent;
            chest.maxAttemptsEvent += OnMaxAttemptsEvent;
        }

        public void OnFoundCodeEvent(Chest c)
        {
            Console.WriteLine("Chest code found ! Secret code was {0}", c.getCode());
        }

        public void OnMaxAttemptsEvent(Chest c) {

            Console.WriteLine("Exceeded max attempts!");
            Console.WriteLine("Chest lock state {0}", c.getLockState());
        }
    }
}
