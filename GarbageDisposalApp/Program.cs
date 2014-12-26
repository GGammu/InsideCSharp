using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageDisposalApp
{
    public class Thing
    {
        private string name;
        public Thing(string name) { this.name = name; }
        public override string ToString()
        {
            return name;
        }
        ~Thing() { Console.WriteLine("~Thing()"); }
        public void Dispose()
        {
            Console.WriteLine("Dispose()");
            GC.SuppressFinalize(this);
        }
    }
    class Program
    {
        public static void DoSomething()
        {
            Thing t = new Thing("Foo");
            Console.WriteLine(t);
            t.Dispose();
            t = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        static void Main(string[] args)
        {
            DoSomething();
            Console.WriteLine("end of Main");
        }
    }
}
