using System;
using System.Collections.Generic;
using System.Text;

namespace _200316_Exo05_Chest_Event
{
    public class Chest
    {
        public delegate void maxAttempts(Chest publisher);
        public delegate void foundCode(Chest publisher);

        public event maxAttempts maxAttemptsEvent;
        public event foundCode foundCodeEvent;

        private int secretCode;
        private int attemptsMade;
        private int maxAttemptsAllowed;
        private bool securityLock;
        private bool HasFoundCode;

        public Chest(Random random, int maxAttemptsAllowed = 10)
        {
            secretCode = random.Next(0, 10000);

            // TODO : Remove line bellow after proven to work.
            Console.WriteLine("Secret code is {0}", secretCode);
            Console.WriteLine("Max Attempts allowed: {0}", maxAttemptsAllowed);

            attemptsMade = 0;
            this.maxAttemptsAllowed = maxAttemptsAllowed;
            securityLock = false;
            HasFoundCode = false;
        }

        public void TryCode(int attempt)
        {

            if (!securityLock && !HasFoundCode)
            {

                attemptsMade++;

                if (attempt == secretCode)
                {
                    HasFoundCode = true;

                    if (foundCodeEvent != null)
                        foundCodeEvent(this);
                }

                if (attemptsMade >= maxAttemptsAllowed)
                {
                    LockChest();
                 
                    if (maxAttemptsEvent != null)
                        maxAttemptsEvent(this);
                }

                Console.WriteLine("Attempts made: {0}", getAttemptsMade());
            }
            else if (securityLock)
            {
                //TODO : Replace with Exception
                Console.WriteLine("Attempt ignored. Chest is locked!");
            }
            else
            {
                Console.WriteLine("Code has already been found in {0} attempts.", getAttemptsMade());
            }

        }

        private void LockChest() { securityLock = true; }
        public int getCode() => secretCode;
        public int getAttemptsMade() => attemptsMade;
        public bool getLockState() => securityLock;

        public bool getFoundState() => HasFoundCode;
    }
}
