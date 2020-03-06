using System;
using static Simple_IO.AskData;

namespace _200305_Trader
{
    class Program
    {
        static Trader trader1;
        static Trader trader2;
        static Trader trader3;

        static Action actionMicrosoft;
        static Action actionApple;
        static Action actionGoogle;

        static RandomGenerator randogen;
        static void Main(string[] args)
        {
            Console.WriteLine("Exo 1: Trader");

            trader1 = new Trader("Tata");
            trader2 = new Trader("Toto");
            trader3 = new Trader("Titi");

            randogen = new RandomGenerator();

            actionMicrosoft = new Action("Microsoft", randogen);
            actionApple = new Action("Apple", randogen);
            actionGoogle = new Action("Google", randogen);

            actionMicrosoft.AddObserver(trader1);
            actionMicrosoft.AddObserver(trader2);
            actionMicrosoft.AddObserver(trader3);

            actionApple.AddObserver(trader1);
            actionApple.AddObserver(trader2);
            actionApple.AddObserver(trader3);

            actionGoogle.AddObserver(trader1);
            actionGoogle.AddObserver(trader2);
            actionGoogle.AddObserver(trader3);

            int numberOfOperations = askInt("How many iterations should occur?: ");

            for (int i = 0; i < numberOfOperations; i++)
            {
                actionMicrosoft.UpdateValue();
                actionApple.UpdateValue();
                actionGoogle.UpdateValue();
            }
        }
    }
}
