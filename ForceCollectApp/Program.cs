using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForceCollectApp
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
    }
    class Program
    {
        public static void DoSomething()
        {
            Thing t = new Thing("Foo");
            Console.WriteLine(t);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        static void Main(string[] args)
        {
            DoSomething();
            Console.WriteLine("some stuff");

            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            Console.WriteLine("end of Main");
            Console.ReadLine();
        }
    }
}
