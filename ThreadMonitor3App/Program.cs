using System;
using System.Threading;

namespace ThreadMonitor3App
{
    class Database
    {
        public void SaveData(string text)
        {
            Console.WriteLine("[SaveData] Started");
            try
            {
                Monitor.Enter(this);
                Console.WriteLine("[SaveData] Working");
                throw new Exception("ERROR!");
                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(text);
                }
            }
            finally
            {
                Monitor.Exit(this);
                Console.WriteLine("\n[SaveData] Ended");
            }
        }
    }
    class Program
    {
        public static Database db = new Database();

        public static void WorkerThreadMethod1()
        {
            Console.WriteLine("[WorkerThreadMethod1] Started");
            Console.WriteLine("[WorkerThreadMethod1] Calling Database.SaveData");
            try
            {
                db.SaveData("x");
            }
            catch { }
            Console.WriteLine("[WorkerThreadMethod1] Finished");
        }
        public static void WorkerThreadMethod2()
        {
            Console.WriteLine("[WorkerThreadMethod2] Started");
            Console.WriteLine("[WorkerThreadMethod2] Calling Database.SaveData");
            try
            {
                db.SaveData("o");
            }
            catch { }
            Console.WriteLine("[WorkerThreadMethod2] Finished");
        }
        static void Main(string[] args)
        {
            ThreadStart worker1 = new ThreadStart(WorkerThreadMethod1);
            ThreadStart worker2 = new ThreadStart(WorkerThreadMethod2);
            Console.WriteLine("[Main] Creating and startin worker threads");
            Thread t1 = new Thread(worker1);
            Thread t2 = new Thread(worker2);
            t1.Start();
            t2.Start();
            Console.ReadLine();
        }
    }
}
