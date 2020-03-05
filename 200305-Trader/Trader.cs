using System;
using System.Collections.Generic;
using System.Text;

namespace _200305_Trader
{
    class Trader : IObserver
    {
        public string Name { get; set; }
        public List<Action> actions;

        public Trader(string name)
        {
            Name = name;
            actions = new List<Action>();
        }

        public override bool Equals(object obj)
        {
            if ((obj.GetType() == typeof(IObserver)) && (((Trader)obj).Name == this.Name))
                return true;

            return false;
        }

        public void Notify(IObservable observable)
        {
            if (IsActionPossessed(observable))
            {
                if (((Action)observable).Tend == Tendency.FALL)
                    SellAction(observable);

                Console.WriteLine(this+" Sells action " + observable);

            }
            else
            {
                if (((Action)observable).Tend == Tendency.RISE)
                {
                    BuyAction(observable);
                    Console.WriteLine(this + " buys action" + observable);
                }

                if (((Action)observable).Tend == Tendency.IDLE)
                {
                    Console.WriteLine("Meh" +" said "+this);
                }

            }
        }

        public override string ToString()
        {
            return Name;
        }

        private void BuyAction(IObservable observable)
        {
            if (!IsActionPossessed(observable))
                actions.Add((Action)observable);
        }

        private void SellAction(IObservable observable)
        {
            if (IsActionPossessed(observable))
                actions.Remove((Action)observable);
        }

        private bool IsActionPossessed(IObservable observable)
        {
            if (actions.Find(a => a.Equals(observable)) != null)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
