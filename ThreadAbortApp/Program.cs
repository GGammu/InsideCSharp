using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAbortApp
{
    class Program
    {
        public static void DoCouting()
        {
            Console.WriteLine("\n[Docounting] Counting slowly to 10");

            for (int i = 0; i < 10; i++)
            {
                if (3 == i)
                    throw new Exception("[DoCounting] Error counting");

                Thread.Sleep(500);
                Console.Write("{0}...", i);
            }
        }

        public static void WorkerThreadMethod()
        {
            Console.WriteLine("\n[WorkerthreadMethod] Thread started");

            int attempts = 1;

            Work:

            try
            {
                Console.WriteLine("[WorkerThreadMethod] Attempt #{0} to call DoCounting", attempts);

                DoCouting();

                Console.WriteLine("\n[WorkerthreadMethod] Finished counting");
            }
            catch (Exception)
            {
                Console.WriteLine("\n\n[WorkerThreadMethod] Retrying work");
                goto Work;
            }
        }

        static void Main(string[] args)
        {
            ThreadStart worker = new ThreadStart(WorkerThreadMethod);

            Console.WriteLine("[Main] Creating worker thread");

            Thread t = new Thread(worker);
            t.Start();

            Console.WriteLine("[Main] Sleeping for 2 seconds");
            Thread.Sleep(2000);

            Console.WriteLine("\n[Main] Tired of waiting - aborting thread");
            t.Abort();
            Console.ReadLine();
        }
    }
}
