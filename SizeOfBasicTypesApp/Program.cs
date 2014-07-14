using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeOfBasicTypesApp
{
    class Program
    {
        unsafe static void Main(string[] args)
        {
            SomeClass.ShowSizes();
            Console.ReadLine();
        }
    }
}
