using System;
using System.Collections.Generic;
using System.Text;

namespace _200306_Exo03_BossMonster.Exceptions
{
    public class DeckFullException : Exception
    {
        public DeckFullException() { }
        public DeckFullException(string message) : base(message) { }
        public DeckFullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
