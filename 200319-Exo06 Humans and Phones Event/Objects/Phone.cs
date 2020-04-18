using System;
using System.Threading;
using _200319_Exo06_Humans_and_Phones.Enums;

namespace _200319_Exo06_Humans_and_Phones.Objects
{
   public class Phone
   {
      public Phone(string name)
      {
         Name = name;
         State = Phone_State.IDLE;
      }

      public string Name { get; set; }
      public Phone_State State { get; set; }
      public event EventHandler PhoneRinging;
      public event EventHandler PhoneNotRinging;

      public void Ring()
      {
         Console.Clear();
         Console.WriteLine("========");
         State = Phone_State.RINGING;
         Console.WriteLine(Name + " is " + State);

         if (PhoneRinging != null)
            PhoneRinging(this, EventArgs.Empty);

         Console.WriteLine("--------");

         Thread.Sleep(3000);

         State = Phone_State.IDLE;

         if (PhoneNotRinging != null)
            PhoneNotRinging(this, EventArgs.Empty);
      }
   }
}