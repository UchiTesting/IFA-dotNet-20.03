using System;
using System.Collections.Generic;
using System.Text;
using _200319_Exo07_Pool_and_Weather.Interfaces;
using _200319_Exo07_Pool_and_Weather.Enums;

namespace _200319_Exo07_Pool_and_Weather.Objects
{
    public class Tap : AbstractFlowing, PoolListener
    {
        public event EventHandler TapOpenEvent;
        public event EventHandler TapCloseEvent;
        //public event EventHandler FlowChange; Le flux est constant dans l'exercice de base. A voir plus tard.
        //public event EventHandler TapFlowChangeEvent;

        public Tap(double flow = 0.2) : base(flow) { Flow = flow; State = VolumeChangerStateEnum.DISABLED; }

        public void Open()
        {
            State = VolumeChangerStateEnum.ACTIVE;
            if (TapOpenEvent != null)
            {
                TapOpenEvent(this, EventArgs.Empty);
            }
        }
        public void Close()
        {
            State = VolumeChangerStateEnum.DISABLED;
            if (TapCloseEvent != null)
            {
                TapCloseEvent(this, EventArgs.Empty);
            }
        }

        public void OnPoolSpilling(object sender, EventArgs e)
        {
            if (State == VolumeChangerStateEnum.ACTIVE)
                Close();
        }
        public void OnPoolFull(object sender, EventArgs e)
        {
            Close();
        }
        public void OnPoolEmpty(object sender, EventArgs e)
        {
            Open();
        }

        public override string ToString()
        {
            return string.Format("Tap state: {0}\nTap flow: {1}\n", State, Flow);
        }
    }
}
