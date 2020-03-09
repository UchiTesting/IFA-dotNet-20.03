using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _200306_Exo03_BossMonster.Exceptions
{
    /// <summary>
    /// Exception meant to manage an empty deck.
    /// If we try to remove a card from an already empty deck,
    /// this exception is thrown.
    /// Can also be used if in the construction of the dundeaon the deck on the right is empty.
    /// </summary>
    class DeckEmptyException : Exception
    {
        public DeckEmptyException()
        {
        }

        public DeckEmptyException(string message) : base(message)
        {
        }

        public DeckEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeckEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
