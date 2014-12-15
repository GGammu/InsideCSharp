using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegatesCallback
{
    class Program
    {
        public static int Add(int op1, int op2, out int result)
        {
            Thread.Sleep(3000);
            return (result = op1 + op2);
        }
        public delegate int AddDelegate(int op1, int op2, out int result);
        public static void AnnounceSum(IAsyncResult iar)
        {
            AddDelegate add = (AddDelegate)iar.AsyncState;
            int result;
            add.EndInvoke(out result, iar);
            Console.WriteLine("[AnnounceSum] The result is {0}", result);
        }
        static void Main(string[] args)
        {
            int result;
            AddDelegate add = new AddDelegate(Add);
            Console.WriteLine("[Main] Invoking the asynchronous  Add method");
            add.BeginInvoke(6, 42, out result, new AsyncCallback(AnnounceSum), add);
            Thread.Sleep(1000);
            Console.ReadLine();
        }
    }
}
