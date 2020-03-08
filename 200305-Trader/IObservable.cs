using System;
using System.Collections.Generic;
using System.Text;

namespace _200305_Exo01_Trader
{
    public interface IObservable
    {
        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void RemoveObserver(int idx);
        public void NotifyAll();
    }
}
