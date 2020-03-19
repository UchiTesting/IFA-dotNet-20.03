using System;
using System.Collections.Generic;
using System.Text;
using _200319_Exo07_Pool_and_Weather.Enums;

namespace _200319_Exo07_Pool_and_Weather.Objects
{
    public abstract class AbstractFlowing
    {
        public double Flow { get; set; }
        public VolumeChangerStateEnum State { get; set; }

        protected AbstractFlowing(double flow)
        {
            Flow = flow;
        }
    }
}
