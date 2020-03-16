using System;
using System.Collections.Generic;
using System.Text;

namespace _200316_Exo04_Events
{
    public class CounterListener
    {
        private Counter counter; // Has an instance of the object listened to.

        public CounterListener(Counter counter)
        {
            this.counter = counter;
            counter.ThresholdReachedEvent += OnThresholdReached; // Registering event OnThresholdReached handler;
        }

        // We use the EventHandler delegate in Counter class which asks for an object and EventArgs as parameters.
        public void OnThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("Counter \""+((Counter)sender)+"\" has reached its threshold of "+ ((Counter)sender).Threshold);
            ((Counter)sender).Stop = true;
        }
    }
}
