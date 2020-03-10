using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _200303_Pokemon.Exceptions
{
    class CannotRemoveHP_OnDeadEnemyException : Exception
    {
        public CannotRemoveHP_OnDeadEnemyException()
        {
        }

        public CannotRemoveHP_OnDeadEnemyException(string message) : base(message)
        {
        }

        public CannotRemoveHP_OnDeadEnemyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannotRemoveHP_OnDeadEnemyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
