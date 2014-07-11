using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInh3App
{
    class Base : ITest
    {
        public void Foo()
        {
            Console.WriteLine("Base.Foo (Itest implementation)");
        }
    }
}
