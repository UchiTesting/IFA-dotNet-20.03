using System;
using static Simple_IO.AskData;

namespace _200316_Exo05_Chest_Event
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ex 05: Chest Event");

            Random random = new Random();

            Chest myChest = new Chest(random, 5);
            ChestListener myChestListener = new ChestListener(myChest);

            do
            {
                int attempt = askInt("Please input a code to try: ");
                myChest.TryCode(attempt);
            } while (!myChest.getLockState() && !myChest.getFoundState());
        }
    }
}
