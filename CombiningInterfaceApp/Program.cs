using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombiningInterfaceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CombiningInterfacesApp.Main " +
                ": Instantianting a MyTreeView class\n");

            MyTreeView tree = new MyTreeView();

            Console.WriteLine("Calling MyTreeView.Drag");
            tree.Drag();
            Console.WriteLine("");

            Console.WriteLine("Calling MyTreeView.Drop");
            tree.Drop();
            Console.WriteLine("");

            Console.WriteLine("Calling MyTreeView.Serialize");
            tree.Serialize();
            Console.WriteLine("");

            Console.ReadLine();

        }
    }
}
