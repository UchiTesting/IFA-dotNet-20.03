using System;
using System.Collections.Generic;
using _200319_Exo06_Humans_and_Phones.Objects;

namespace _200319_Exo06_Humans_and_Phones_Event
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         Console.WriteLine("Exo06: Humans and Phones with events");

         // Setting up humans
         var humans = new List<Human>();
         var Devon = new Human("Devon");
         var John = new Human("John");
         var Alice = new Human("Alice");
         humans.Add(Alice);
         humans.Add(Devon);
         humans.Add(John);

         // Setting up phones
         var phones = new List<Phone>();
         var Samsung = new Phone("Samsung");
         var Apple = new Phone("Apple");
         var Playskool = new Phone("Playskool");
         phones.Add(Apple);
         phones.Add(Playskool);
         phones.Add(Samsung);

         //Adding Phones to Humans
         Devon.AddPhone(Apple);
         Devon.AddPhone(Samsung);
         John.AddPhone(Samsung);
         Alice.AddPhone(Playskool);


         humans.ForEach(h => phones.ForEach(p => p.PhoneRinging += h.OnPhoneRinging));
         humans.ForEach(h => phones.ForEach(p => p.PhoneNotRinging += h.OnPhoneNotRinging));


         var stop = false;
         do
         {
            checkInput(ref stop);
            phones.ForEach(p => p.Ring());
         } while (!stop);
      }

      private static void checkInput(ref bool stop)
      {
         var pressedKey = ConsoleKey.NoName;

         if (Console.KeyAvailable)
         {
            pressedKey = Console.ReadKey().Key;

            if (pressedKey == ConsoleKey.Escape)
               stop = true;
         }
      }
   }
}