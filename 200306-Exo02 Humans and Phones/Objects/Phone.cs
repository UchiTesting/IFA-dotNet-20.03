using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using _200306_Exo02_Humans_and_Phones.Enums;

namespace _200306_Exo02_Humans_and_Phones.Objects
{
    public class Phone : AbstractObservable
    {
        public Phone_State State { get; set; }

        public Phone(string name) : base(name) { State = Phone_State.IDLE; }

        public void Ring()
        {
            Console.Clear();
            Console.WriteLine("========");
            State = Phone_State.RINGING;
            Console.WriteLine(Name + " is " + State);
            Console.WriteLine("--------");
            NotifyAll();
            Thread.Sleep(3000);
            State = Phone_State.IDLE;
        }
    }
}
