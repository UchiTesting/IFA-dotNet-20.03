using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _200316_Exo04_Events
{
    public class Counter // Publisher class that will generate the event.
    {
        // delegate void Sytem.EventHandler(object sender, System.EventArgs e); ← Implicit / already defined in C#

        public event EventHandler ThresholdReachedEvent; // Instance of the above implicite line.

        public string Name { get; set; }
        public int Threshold { get; set; } // Variable used to decide when to send an event. Can be anything.
        public int CurrentValue { get; set; }
        public bool Stop { get; set; }

        // Just a constructor like any other class.
        public Counter(string name, int threshold)
        {
            Name = name;
            Threshold = threshold;

            CurrentValue = 0;
            Stop = false;
        }
        protected virtual void ThresholdReached(EventArgs e) // Method that will be called
        {
            if (ThresholdReachedEvent != null) // If there's a subscriber...
            {
                ThresholdReachedEvent(this, e);
            }
        }

        public void Process()
        {
            CurrentValue++; // Any process that would make the event possible.
            if ((CurrentValue >= Threshold)) // If the condition occurs, send the event.
            {
                ThresholdReached(EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
