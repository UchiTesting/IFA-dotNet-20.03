using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using _200319_Exo07_Pool_and_Weather.Interfaces;
using _200319_Exo07_Pool_and_Weather.Enums;

namespace _200319_Exo07_Pool_and_Weather.Objects
{
    public class Pool
    {
        double Volume { get; set; }
        double CurrentVolume { get; set; }
        double Flow { get; set; }

        List<AbstractFlowing> flowings;

        public event EventHandler EmptyEvent;
        public event EventHandler FullEvent;
        public event EventHandler SpillingEvent;
        public Pool(double volume = 50)
        {
            Volume = volume;
            CurrentVolume = 0;
            Flow = 0;
            flowings = new List<AbstractFlowing>();

        }

        public void UpdateVolume()
        {
            Flow = ComputeFlow();
            if (Flow != 0)
            {
                CurrentVolume += Flow;
                Thread.Sleep(1000);
                UpdateVolume();
            }
            if (CurrentVolume < 0) CurrentVolume = 0;

            if (CurrentVolume <= Volume * 0.95)
                EmptyEvent(this, EventArgs.Empty);

            if (CurrentVolume >= Volume)
                SpillingEvent(this, EventArgs.Empty);

            if (CurrentVolume >= Volume * 0.95) 
                FullEvent(this, EventArgs.Empty);
        }

        private double ComputeFlow()
        {
            double sum = 0.0;

            flowings.ForEach(f => { if (f.State == VolumeChangerStateEnum.ACTIVE) sum += f.Flow; });
            return sum;
        }

        public void AddFlowing(AbstractFlowing f)
        {
            flowings.Add(f);
        }

        public void RemoveFlowing(AbstractFlowing f)
        {
            AbstractFlowing temp = flowings.Find(flowing => flowing == f);

            if (temp != null)
                flowings.Remove(temp);
        }

        public void RemoveFlowing(int idx) { flowings.RemoveAt(idx); }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Pool Information");
            sb.AppendLine("========");
            sb.AppendLine("Total volume: "+ Volume);
            sb.AppendLine("Current volume: "+ CurrentVolume);
            sb.AppendLine("--------");
            sb.AppendLine("Pool Flow Information");
            sb.AppendLine("Flow: "+ ComputeFlow());
            sb.AppendLine("Detail");
            sb.AppendLine("---------");

            flowings.ForEach(f => sb.AppendLine(f.ToString()));

            return sb.ToString();
        }
    }
}
