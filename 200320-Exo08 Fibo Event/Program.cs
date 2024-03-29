﻿using System;
using System.Numerics;
using System.Collections.Generic;
using System.Threading;

using static Simple_IO.AskData;
using System.Diagnostics;

namespace _200320_Exo08_Fibo_Event
{
    enum MenuActionEnum
    {
        NONE,
        FIBONORMAL,
        FIBOOOPTIMISE,
        QUITTER
    }

    class Program
    {
        public static event EventHandler<FiboArgs> ThreadFinishedEvent;
        static void Main(string[] args)
        {
            int N;
            MenuActionEnum choix = MenuActionEnum.NONE;
            List<Thread> threads = new List<Thread>();

            ThreadFinishedEvent += DisplayFiboEnd.OnThreadFinishedEvent;

            while (choix != MenuActionEnum.QUITTER)
            {
                DisplayMenu();
                choix = (MenuActionEnum)AskInt("Choix: ");

                if (choix == MenuActionEnum.FIBONORMAL)
                    SetupAndRunFibo(threads, FiboNormalThread);

                if (choix == MenuActionEnum.FIBOOOPTIMISE)
                    SetupAndRunFibo(threads, FiboOptiThread);
            }

            Console.WriteLine("En attente des threads..");
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("Threads finis, on peut quitter");

        }

        private static void SetupAndRunFibo(List<Thread> threads, ParameterizedThreadStart fiboToRun)
        {
            int N = AskInt("Valeur n de fibo: ");
            Thread t = new Thread(fiboToRun);
            threads.Add(t);
            t.Start(N);
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Quelle version ?");
            Console.WriteLine("1) Normal");
            Console.WriteLine("2) Optimisée");
            Console.WriteLine("3) Quitter");
        }

        static void FiboNormalThread(object n)
        {
            FiboArgs fa = new FiboArgs();
            fa.n = (int)n;
            Stopwatch execTime;
            Console.WriteLine("Fibo normal pour N = " + fa.n);
            execTime = Stopwatch.StartNew();
            fa.result = Fibo(fa.n);
            execTime.Stop();
            Console.WriteLine("Execution time = " + execTime.ElapsedMilliseconds);
            ThreadFinishedEvent(null, fa);
        }
        static BigInteger Fibo(int n)
        {
            return n <= 1 ? n : Fibo(n - 1) + Fibo(n - 2);
        }

        static void FiboOptiThread(object n)
        {
            Stopwatch execTime;
            FiboArgs fa = new FiboArgs();
            fa.n = (int)n;
            Console.WriteLine("Fibo opti pour N = " + fa.n);
            BigInteger[] tabFiboOpti = new BigInteger[fa.n + 1];

            execTime = Stopwatch.StartNew();
            fa.result = FiboOpti(fa.n, ref tabFiboOpti);
            execTime.Stop();
            Console.WriteLine("Execution time = " + execTime.ElapsedMilliseconds);
            ThreadFinishedEvent(null, fa);
        }
        static BigInteger FiboOpti(int n, ref BigInteger[] tab)
        {
            if (tab[n] == 0)
                tab[n] = n <= 1 ? n : FiboOpti(n - 1, ref tab) + FiboOpti(n - 2, ref tab);

            return tab[n];
        }

    }
}
