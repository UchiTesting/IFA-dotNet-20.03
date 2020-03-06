using System;
using System.Collections.Generic;
using System.Text;

namespace _200305_Trader
{
    public class Action : IObservable
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double PreviousValue { get; set; }
        public Tendency Tend { get; set; }
        Random Rnd;

        List<IObserver> observers;

        public Action(string name, Random rnd)
        {
            Name = name;
            Rnd = rnd;

            Value = Rnd.NextDouble();
            PreviousValue = Value;
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Find(o => o.Equals(observer));
        }

        public void RemoveObserver(int idx)
        {
            observers.RemoveAt(idx);
        }

        public void NotifyAll()
        {
            observers.ForEach(o => o.Notify(this));
        }

        public void UpdateValue()
        {
            Value = Rnd.NextDouble();
            UpdateTendency();
            Console.WriteLine(this.ToString());
            NotifyAll();
        }

        private Tendency UpdateTendency()
        {
            if (Value > PreviousValue)
                return Tend = Tendency.RISE;
            if (Value < PreviousValue)
                return Tend = Tendency.FALL;

            return Tend = Tendency.IDLE;
        }

        public override string ToString()
        {
            return Name + " with value "+ Value + " and tendency " + Tend;
        }
    }
}
