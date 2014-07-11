using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInh3App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("InterfaceInh3App.Main : " +
                "Instantiating a MyDerived class");
            MyDerived myDerived = new MyDerived();
            Console.WriteLine();

            Console.WriteLine("InterfaceInh3App.Main : " +
                "Calling MyDerived.Foo - Which method will be " +
                "called?");

            myDerived.Foo();
            Console.WriteLine();

            Console.WriteLine("InterfaceInh3App.Main : " +
                "Calling MyDerived.Foo - Casting to ITest " +
                "interface...");

            ((ITest)myDerived).Foo();

            Console.ReadLine();
        }
    }
}
