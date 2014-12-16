using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TypeObjectFromNameApp
{
    class Program
    {
        public static void DisplaySyntax()
        {
            Console.WriteLine("\nSyntax: TypeObjectFromName <typename>\n");
        }
        public static void DisplaytypeInfo(string typeName)
        {
            try
            {
                Type type = Type.GetType(typeName, true);
                Console.WriteLine("\n'{0}' is located in the module {1}", 
                    typeName, type.Module);
            }
            catch (TypeLoadException e)
            {
                Console.WriteLine("\n'{0}' could not be located. Did you " +
                    "qualify with a namespace?", typeName);
            }
        }
        static void Main(string[] args)
        {
            if (1 != args.Length)
                DisplaySyntax();
            else
                DisplaytypeInfo(args[0]);

            Console.ReadLine();
        }
    }
}
