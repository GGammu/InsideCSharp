using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegatesBlocked
{
    class Program
    {
        public static int Add(int op1, int op2, out int result)
        {
            Thread.Sleep(3000);
            return (result = op1 + op2);
        }
        public delegate int AddDelegate(int op1, int op2, out int result);
        static void Main(string[] args)
        {
            int result;
            AddDelegate add = new AddDelegate(Add);
            Console.WriteLine("[Main] Invoking the asynchronous Add method");
            IAsyncResult iAR = add.BeginInvoke(6, 42, out result, null, null);
            Console.Write("[Main] Doing other work");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
            Console.WriteLine("\n[Main] Waiting for Add to finish");
            iAR.AsyncWaitHandle.WaitOne();
            Console.WriteLine("[Main] Add finished, cleaning up");
            add.EndInvoke(out result, iAR);
            Console.WriteLine("[Main] The result is {0}", result);
            Console.ReadLine();
        }
    }
}
