using System;

namespace _200316_Exo04_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exo 04 : Events");

            Random random = new Random();

            int threshold = random.Next(10,20);
            Counter counter = new Counter("My Counter object", threshold);
            CounterListener counterListener = new CounterListener(counter);

            do
            {
                Console.WriteLine("Current value: {0} | Threshold {1}",counter.CurrentValue, counter.Threshold);
                counter.Process();
            } while (!counter.Stop);

        }
    }
}
