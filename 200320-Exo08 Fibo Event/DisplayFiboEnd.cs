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

            Console.WriteLine("{0}: Finished to compute Fibo for N={1}. Result: {2}", timestamp, fa.n,fa.result);
        }
    }
}
