using System;
using System.Collections.Generic;
using System.Text;

namespace _200305_Trader
{
    public class RandomGenerator : Random
    {
        Random rnd;

        public RandomGenerator()
        {
            rnd = new Random();
        }

        public double generate()
        {
            return rnd.NextDouble();
        }
    }
}
