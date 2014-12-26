using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGCApp
{
    public class Thing
    {
        protected string name;
        public Thing(string name) 
        { 
            this.name = name;
            Console.WriteLine("Thing()");
        }
        public override string ToString()
        {
            return name;
        }
        ~Thing() { Console.WriteLine("~Thing"); }
    }
    public class SonOfThing : Thing
    {
        public SonOfThing(string name) : base(name) 
        {
            Console.WriteLine("SonOfThing()");
        }
        public override string ToString()
        {
            return name;
        }
        ~SonOfThing()
        {
            Console.WriteLine("~SonOfThing");
        }
    }
    class Program
    {
        static void DoSomething()
        {
            SonOfThing t = new SonOfThing("Foo");
            Console.WriteLine(t);
        }
        static void Main(string[] args)
        {
            DoSomething();
            Console.WriteLine("end of Main");
            //Console.ReadLine();
        }
    }
}
