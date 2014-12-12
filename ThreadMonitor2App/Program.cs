using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadMonitor2App
{
    class Database
    {
        public void SaveData(string text)
        {
            Console.WriteLine("[SaveData] Started");
            Monitor.Enter(this);
            Console.WriteLine("[SaveData] Working");
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(100);
                Console.Write(text);
            }
            Monitor.Exit(this);
            Console.WriteLine("\n[SaveData] Ended");
        }
    }
    class Program
    {
        public static Database db = new Database();

        public static void WorkerThreadmethod1()
        {
            Console.WriteLine("[WorkerThreadMethod1] Started");
            Console.WriteLine("[WorkerThreadMethod1] Calling Database.SaveData");
            db.SaveData("x");
            Console.WriteLine("[WorkerThreadMethod1] Finished");
        }
        public static void WorkerThreadMethod2()
        {
            Console.WriteLine("[WorkerThreadMethod2] Started");
            Console.WriteLine("[WorkerThreadMethod2] Calling Database.SaveData");
            db.SaveData("o");
            Console.WriteLine("[WorkerThreadMethod2] Finished");
        }
        static void Main(string[] args)
        {
            ThreadStart worker1 = new ThreadStart(WorkerThreadmethod1);
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
