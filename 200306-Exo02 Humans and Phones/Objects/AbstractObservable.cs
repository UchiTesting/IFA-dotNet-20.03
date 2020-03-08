using System.Collections.Generic;

namespace _200306_Exo02_Humans_and_Phones.Objects
{
    public abstract class AbstractObservable
    {
        protected List<AbstractObserver> observers;
        protected string Name;

        protected AbstractObservable(string name)
        {
            Name = name;
            observers = new List<AbstractObserver>();
        }
        public void NotifyAll()
        {
            observers.ForEach(o => o.Notify());
        }

        public void AddObserver(AbstractObserver observer)
        {
            observers.Add(observer);
        }

        public void AddObservers(List<AbstractObserver> appendedObservers)
        {
            observers.AddRange(appendedObservers);
        }

        public void RemoveObserver(int idx)
        {
            observers.RemoveAt(idx);
        }

        public void RemoveObserver(AbstractObserver obs)
        {
            AbstractObserver tmpObserver = observers.Find(o => o.Equals(obs));
            if (tmpObserver != null)
                observers.Remove(tmpObserver);
        }
    }
}
