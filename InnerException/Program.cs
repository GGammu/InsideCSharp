using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerException
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateArgs validateArgs = new ValidateArgs();

            try
            {
                validateArgs.DoWork(args[0]);
            }
            catch (Exception e)
            {
                if (null != e.InnerException)
                {
                    Exception inner = e.InnerException;
                    Console.WriteLine(inner.Message);

                    Console.WriteLine("Syntax: InnerException x.y");
                    Console.WriteLine("\tx = major version number");
                    Console.WriteLine("\tx = minor version number");
                }
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
