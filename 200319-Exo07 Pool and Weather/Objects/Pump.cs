using System;
using System.Collections.Generic;
using System.Text;
using _200319_Exo07_Pool_and_Weather.Interfaces;
using _200319_Exo07_Pool_and_Weather.Enums;

namespace _200319_Exo07_Pool_and_Weather.Objects
{
    public class Pump : AbstractFlowing, PoolListener
    {
        public event EventHandler PumpOnEvent;
        public event EventHandler PumpOffEvent;
        public Pump(double flow = -0.5) : base(flow) { Flow = flow; if (Flow > 0) Flow = -Flow; State = VolumeChangerStateEnum.DISABLED; }

        public void SetPumpOn()
        {
            State = VolumeChangerStateEnum.ACTIVE;

            if (PumpOnEvent != null)
                PumpOnEvent(this, EventArgs.Empty);
        }
        public void SetPumpOff()
        {
            State = VolumeChangerStateEnum.DISABLED;

            if (PumpOffEvent != null)
                PumpOffEvent(this, EventArgs.Empty);
        }

        public void OnPoolSpilling(object sender, EventArgs e)
        {
            SetPumpOn();
        }

        public void OnPoolFull(object sender, EventArgs e)
        {
            SetPumpOff();
        }

        public void OnPoolEmpty(object sender, EventArgs e)
        {
            SetPumpOff();
        }

        public override string ToString()
        {
            return string.Format("Pump state: {0}\nPump flow: {1}\n", State, Flow);
        }
    }
}
