using _200319_Exo07_Pool_and_Weather.Enums;
using _200319_Exo07_Pool_and_Weather.Objects;
using System;
using System.Threading;

namespace _200319_Exo07_Pool_and_Weather
{
    class Program
    {
        static Random numberGenerator;
        static bool MainStop;

        static Pool myPool;
        static Tap tap;
        static Pump pump;
        static Weather weather;

        static Thread weatherThread;
        static Thread poolThread;
        static Thread displayThread;

        static readonly object synlock = new object();
        static readonly object synlockObj = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Ex: 07 Pool and Weather");

            numberGenerator = new Random();
            MainStop = false;
            Console.CursorVisible = false;

            // Creating objects
            myPool = new Pool(); // Default value is 50.0
            tap = new Tap(); // Default 0.2
            pump = new Pump(); // Default value 0.5

            weather = Weather.GetInstance();

            myPool.AddFlowing(tap);
            myPool.AddFlowing(pump);
            myPool.AddFlowing(weather);

            // Registering event handlers
            myPool.EmptyEvent += tap.OnPoolEmpty;
            myPool.EmptyEvent += pump.OnPoolEmpty;

            myPool.FullEvent += tap.OnPoolFull;
            myPool.FullEvent += pump.OnPoolFull;

            myPool.SpillingEvent += tap.OnPoolSpilling;
            myPool.SpillingEvent += pump.OnPoolSpilling;

            // Creating Threads
            displayThread = new Thread(ThreadDisplay);
            displayThread.Start();

            weatherThread = new Thread(ThreadWeather);
            weatherThread.Start();

            poolThread = new Thread(ThreadPool);
            poolThread.Start();

            displayThread.Join();
            weatherThread.Join();
            poolThread.Join();

        }
        public static void ThreadDisplay(object o)
        {
            do
            {
                lock (synlock)
                {
                    //Console.Clear();
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine(myPool.ToString());
                }
            } while (!MainStop);
        }
        public static void ThreadWeather(object o)
        {
            do
            {
                    weather.UpdateWeather(((WeatherEnum)numberGenerator.Next(1, 5)));
                    Thread.Sleep(numberGenerator.Next(5 * 1000, 20 * 1000)); // Weather is unpredictable.
            } while (!MainStop);
        }

        public static void ThreadPool(object o)
        {
            do
            {
                    myPool.UpdateVolume();
                    Thread.Sleep(1000); //Volume of water must be updated regularly
            } while (!MainStop);
        }
    }
}
