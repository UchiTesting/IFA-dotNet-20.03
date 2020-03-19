using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using _200319_Exo06_Humans_and_Phones.Enums;

namespace _200319_Exo06_Humans_and_Phones.Objects
{
    public class Phone
    {
        public event EventHandler PhoneRinging;
        public event EventHandler PhoneNotRinging;

        public Human Owner { get; set; }
        public string Name { get; set; }
        public Phone_State State { get; set; }

        public Phone(string name)
        {
            Name = name;
            Owner = owner;
            State = Phone_State.IDLE;
        }

        public void Ring()
        {
            Console.Clear();
            Console.WriteLine("========");
            State = Phone_State.RINGING;

            if (PhoneRinging != null)
                PhoneRinging(this, EventArgs.Empty);

            Console.WriteLine(Name + " is " + State);
            Console.WriteLine("--------");

            Thread.Sleep(3000);

            State = Phone_State.IDLE;

            if (PhoneNotRinging != null)
                PhoneNotRinging(this, EventArgs.Empty);
        }
    }
}
