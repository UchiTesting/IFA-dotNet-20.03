using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    interface IObservable
    {
        public void AddObserver();
        public void RemoveObserver();
        public void NotifyAll();
    }
}
