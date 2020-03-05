using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _200303_Pokemon.Exceptions
{
    class CannotAttackDeadEnemyException : Exception
    {
        public CannotAttackDeadEnemyException()
        {
        }

        public CannotAttackDeadEnemyException(string message) : base(message)
        {
        }

        public CannotAttackDeadEnemyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannotAttackDeadEnemyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
