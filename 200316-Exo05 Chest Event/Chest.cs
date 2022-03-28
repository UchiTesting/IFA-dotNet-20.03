using System;
using System.Collections.Generic;
using System.Text;

namespace _200316_Exo05_Chest_Event
{
    public class Chest
    {
        public delegate void MaxAttempts(Chest publisher);
        public delegate void FoundCode(Chest publisher);

        public event EventHandler Sometho;

        public event MaxAttempts MaxAttemptsEvent;
        public event FoundCode FoundCodeEvent;
        


        private int _secretCode;
        private int _attemptsMade;
        private int _maxAttemptsAllowed;
        private bool _securityLock;
        private bool _hasFoundCode;

        public Chest(Random random, int maxAttemptsAllowed = 10)
        {
            _secretCode = random.Next(0, 10000);

            // TODO : Remove line bellow after proven to work.
            Console.WriteLine("Secret code is {0}", _secretCode);
            Console.WriteLine("Max Attempts allowed: {0}", maxAttemptsAllowed);

            _attemptsMade = 0;
            _maxAttemptsAllowed = maxAttemptsAllowed;
            _securityLock = false;
            _hasFoundCode = false;
        }

        public void TryCode(int attempt)
        {

            if (!_securityLock && !_hasFoundCode)
            {

                _attemptsMade++;

                if (attempt == _secretCode)
                    DeclareAndFireFoundEvent();

                if (_attemptsMade >= _maxAttemptsAllowed)
                    LockForTooManyAttempts();

                Console.WriteLine("Attempts made: {0}", GetAttemptsMade());
            }
            else if (_securityLock)
                Console.WriteLine("Attempt ignored. Chest is locked!");
            else
                Console.WriteLine("Code has already been found in {0} attempts.", GetAttemptsMade());
        }

        private void LockForTooManyAttempts()
        {
            LockChest();
            MaxAttemptsEvent?.Invoke(this);
        }

        private void DeclareAndFireFoundEvent()
        {
            _hasFoundCode = true;
            FoundCodeEvent?.Invoke(this);
        }

        private void LockChest() { _securityLock = true; }
        public int GetCode() => _secretCode;
        public int GetAttemptsMade() => _attemptsMade;
        public bool GetLockState() => _securityLock;

        public bool GetFoundState() => _hasFoundCode;
    }
}
