using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceInh2App
{
    class Program
    {
        static void Main(string[] args)
        {
            EditBox edit = new EditBox();

            IDataBound bound = edit as IDataBound;

            if (bound != null)
            {
                Console.WriteLine("IDataBound is supported...");
                bound.Serialize();
            }
            else
            {
                Console.WriteLine("IDataBound is NOT supported...");
            }
            Console.ReadLine();
        }
    }
}
