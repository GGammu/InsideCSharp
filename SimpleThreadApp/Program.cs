using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleThreadApp
{
    class Program
    {
        public static void WorkerThreadMethod()
        {
            Console.WriteLine("[WorkerThreadMethod] Worker thread started");
        }

        static void Main(string[] args)
        {
            ThreadStart worker = new ThreadStart(WorkerThreadMethod);

            Console.WriteLine("[Main] Creating worker thread");

            Thread t = new Thread(worker);
            t.Start();

            Console.WriteLine("[Main] Have requested the start of worker thread");

            Console.ReadLine();
        }
    }
}
