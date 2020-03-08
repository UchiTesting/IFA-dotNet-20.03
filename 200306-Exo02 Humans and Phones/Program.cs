using System;
using _200306_Exo02_Humans_and_Phones.Objects;
using System.Collections.Generic;

namespace _200306_Exo02_Humans_and_Phones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ex 2 : Humans and Phones");

            // Setting up humans
            List<AbstractObserver> humans = new List<AbstractObserver>();
            Human Devon = new Human("Devon");
            Human John = new Human("John");
            Human Alice = new Human("Alice");
            humans.Add(Alice);
            humans.Add(Devon);
            humans.Add(John);

            // Setting up phones
            List<Phone> phones = new List<Phone>();
            Phone Samsung = new Phone("Samsung");
            Samsung.AddObservers(humans);
            Phone Apple = new Phone("Apple");
            Apple.AddObservers(humans);
            Phone Playskool = new Phone("Playskool");
            Playskool.AddObservers(humans);
            phones.Add(Apple);
            phones.Add(Playskool);
            phones.Add(Samsung);

            //Adding Phones to Humans
            Devon.AddPhone(Apple);
            Devon.AddPhone(Samsung);
            John.AddPhone(Samsung);
            Alice.AddPhone(Playskool);

            bool stop = false;
            do
            {
                checkInput(ref stop);
                phones.ForEach(p => p.Ring());

            } while (!stop);
        }

        private static void checkInput(ref bool stop)
        {
            ConsoleKey pressedKey = ConsoleKey.NoName;

            if (Console.KeyAvailable)
            {
                pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.Escape)
                    stop = true;
            }
        }
    }
}
