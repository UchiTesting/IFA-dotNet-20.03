using System;
using System.Collections.Generic;
using System.Text;

namespace _200305_Trader
{
    public interface IObserver
    {
        public void Notify(IObservable observable);
    }
}
