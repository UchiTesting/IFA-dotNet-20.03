using System;
using System.Collections.Generic;
using System.Text;

namespace _200320_Exo08_Fibo_Event
{
    public class DisplayFiboEnd
    {
        public static void OnThreadFinishedEvent(object sender, FiboArgs fa)
        {
            DateTime timestamp = DateTime.Now;

            Console.WriteLine($"{timestamp}: Finished to compute Fibo for N={fa.n}. Result: {fa.result}");
        }
    }
}
