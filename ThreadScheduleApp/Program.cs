﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadScheduleApp
{
    class Program
    {
        public static void WorkerThreadMethod1()
        {
            Console.WriteLine("Worker thread started");

            Console.WriteLine("Worker thread - counting slowly from 1 to 10");

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(".");
                    //int a;
                    //a = 15;
                }
                Console.Write("{0}", i);
            }
            Console.WriteLine("Worker thread finished");
        }

        public static void WorkerThreadMethod2()
        {
            Console.WriteLine("Worker thrread started");

            Console.WriteLine("Worker thread - counting slowly from 11 to 20");

            for (int i = 11; i < 20; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(".");

                    //int a;
                    //a = 15;
                }

                Console.Write("{0}", i);
            }
            Console.Write("Worker thread finished");
        }
        static void Main(string[] args)
        {
            ThreadStart worker1 = new ThreadStart(WorkerThreadMethod1);
            ThreadStart worker2 = new ThreadStart(WorkerThreadMethod2);

            Console.WriteLine("Main - Creating worker threads");

            Thread t1 = new Thread(worker1);
            Thread t2 = new Thread(worker2);

            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;

            t1.Start();
            t2.Start();

            Console.ReadLine();
        }
    }
}
