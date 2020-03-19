using System;
using System.Collections.Generic;
using System.Text;

namespace _200319_Exo07_Pool_and_Weather.Interfaces
{
    interface TapListener
    {
        public void OnTapOpen(object sender, EventArgs e);
        public void OnTapClose(object sender, EventArgs e);
        //public void OnTapFlowChange(object sender, EventArgs e);
    }
}
