using System;
using System.Collections.Generic;
using _200319_Exo06_Humans_and_Phones.Objects;

namespace _200319_Exo06_Humans_and_Phones_Event
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exo06: Humans and Phones with events");

            // Setting up humans
            List<Human> humans = new List<Human>();
            Human Devon = new Human("Devon");
            Human John = new Human("John");
            Human Alice = new Human("Alice");
            humans.Add(Alice);
            humans.Add(Devon);
            humans.Add(John);

            // Setting up phones
            List<Phone> phones = new List<Phone>();
            Phone Samsung = new Phone("Samsung");
            Phone Apple = new Phone("Apple");
            Phone Playskool = new Phone("Playskool");
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
