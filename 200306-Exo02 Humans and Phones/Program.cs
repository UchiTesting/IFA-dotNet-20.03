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
            List<AbstractObserver> humans = PopulateHumans();

            Human Alice = (Human)humans[0];
            Human Devon = (Human)humans[1];
            Human John = (Human)humans[2];

            // Setting up phones
            List<AbstractObservable> phones = PopulatePhones();

            Phone Apple = (Phone)phones[0];
            Phone Playskool = (Phone)phones[1];
            Phone Samsung = (Phone)phones[2];

            phones.ForEach(phone =>
            {
                phone.AddObservers(humans);
            });

            //Adding Phones to Humans
            Devon.AddPhone(Apple);
            Devon.AddPhone(Samsung);
            John.AddPhone(Samsung);
            Alice.AddPhone(Playskool);

            bool stop = false;
            do
            {
                checkInput(ref stop);
                phones.ForEach(p => (p as Phone).Ring());
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

        private static List<AbstractObserver> PopulateHumans() =>
            new List<AbstractObserver> {
                new Human("Alice"),
                new Human("Devon"),
                new Human("John")
            };

        private static List<AbstractObservable> PopulatePhones() =>
            new List<AbstractObservable> {
                new Phone("Apple"),
                new Phone("Playskool"),
                new Phone("Samsung")
            };
    }
}
