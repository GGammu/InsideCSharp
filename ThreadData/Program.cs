using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadData
{
    class Sum
    {
        public Sum(int op1, int op2)
        {
            Console.WriteLine("[Sum.Sum] Instantiated with values of {0} and {1}", op1, op2);
            this.op1 = op1;
            this.op2 = op2;
        }

        int op1;
        int op2;
        int result;
        public int Result { get { return result; } }

        public void Add()
        {
            Thread.Sleep(5000);
            result = op1 + op2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Main] Instantiating the Sum " + 
                "object and passing it the values ot add");

            Sum sum = new Sum(6, 42);

            Console.WriteLine("[Main] Starting a thread using" +
                "a Sum delegate");

            Thread thread = new Thread(new ThreadStart(sum.Add));
            thread.Start();

            Console.Write("[Main] Doing other work");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }

            Console.WriteLine("\n[Main] Waiting for Add to finish");
            thread.Join();

            Console.WriteLine("[Main] The result is {0}", sum.Result);
            Console.ReadLine();
        }
    }
}
