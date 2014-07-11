using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInh3App
{
    class MyDerived : Base
    {
        public new void Foo()
        {
            Console.WriteLine("MyDerived.Foo");
        }
    }
}
