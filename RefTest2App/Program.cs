using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTest2App
{
    class Foo
    {
        public int i;
    }
    class Program
    {
        public static void ChangeValue(Foo f)
        {
            f.i = 42;
        }

        static void Main(string[] args)
        {
            Foo test = new Foo();

            test.i = 6;

            Console.WriteLine("Befre Method Call");
            Console.WriteLine("test.i={0}", test.i);
            Console.WriteLine();

            ChangeValue(test);

            Console.WriteLine("After Method Call");
            Console.WriteLine("test.i={0}", test.i);

            Console.ReadLine();
        }
    }
}
