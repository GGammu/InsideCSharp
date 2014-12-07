using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSleepApp
{
    class Program
    {
        public static void WorkerThreadMethod()
        {
            Console.WriteLine("[WorkerThreadMethod] Thread started");

            int sleepTime = 5000;

            Console.WriteLine("\tsleeping for {0} seconds", sleepTime / 1000);

            Thread.Sleep(sleepTime);
            Console.WriteLine("\twaking up");
        }

        static void Main(string[] args)
        {
            ThreadStart worker = new ThreadStart(WorkerThreadMethod);

            Console.WriteLine("[Main] Creating worker thread");

            Thread t = new Thread(worker);

            t.Start();

            Console.WriteLine("[Main] Have requested the start of worker thread");

            t.Join();

            Console.WriteLine("[Main] Worker thread finally woke up!");

            Console.ReadLine();
        }
    }
}
