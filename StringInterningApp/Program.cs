using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInterningApp
{
    class Program
    {
        public class Thing
        {
            private int i;
            public Thing(int i) { this.i = i; }
        }

        static void Main(string[] args)
        {
            Thing t1 = new Thing(123);
            Thing t2 = new Thing(123);

            Console.WriteLine(t1 == t2);

            string a = "Hello";
            string b = "Hello";

            Console.WriteLine(a == b);

            Console.ReadLine();
        }
    }
}
