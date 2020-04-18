using System;
using System.Collections.Generic;
using System.Text;

namespace _200319_Exo07_Pool_and_Weather.Interfaces
{
    interface PumpListener
    {
        public void OnPumpOn(object sender, EventArgs e);
        public void OnPumpOff(object sender, EventArgs e);
    }
}
