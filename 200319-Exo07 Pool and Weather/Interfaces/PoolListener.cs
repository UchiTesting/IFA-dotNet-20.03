using System;
using System.Collections.Generic;
using System.Text;

namespace _200319_Exo07_Pool_and_Weather.Interfaces
{
    interface PoolListener
    {
        public void OnPoolSpilling(object sender, EventArgs e);
        public void OnPoolFull(object sender, EventArgs e);
        public void OnPoolEmpty(object sender, EventArgs e);
    }
}
