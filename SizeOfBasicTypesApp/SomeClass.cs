using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeOfBasicTypesApp
{
    class SomeClass
    {
        static unsafe public void ShowSizes()
        {
            Console.WriteLine("\nBasic type sizes");
            Console.WriteLine("sizeof short = {0}", sizeof(short));
            Console.WriteLine("sizeof int = {0}", sizeof(int));
            Console.WriteLine("sizeof long = {0}", sizeof(long));
            Console.WriteLine("sizeof bool = {0}", sizeof(bool));
        }
    }
}
