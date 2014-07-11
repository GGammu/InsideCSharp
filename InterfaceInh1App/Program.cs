using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInh1App
{
    class Program
    {
        static void Main(string[] args)
        {
            EditBox edit = new EditBox();
            edit.Serialize();
            Console.ReadLine();
        }
    }
}
