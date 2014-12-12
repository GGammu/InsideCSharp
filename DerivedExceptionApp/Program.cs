using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivedExceptionApp
{
    class Program
    {
        public static void ThrowException()
        {
            Console.WriteLine("[DerivedExceptionApp.ThrowException] Throwing " +
                "MyExceptionClass exception");

            throw new MyExceptionClass("ERROR encountered!!");
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("[Main] Calling DerievedExceptionApp." +
                    "ThrowException");
                ThrowException();
            }
            catch (Exception e)
            {
                Console.WriteLine("[Main] Caught exception " +
                    "with catch(System.Exception)");
                Console.WriteLine("[Main] Examination is " +
                    "actually of type {0}", e.GetType());
            }

            Console.ReadLine();
        }
    }
}
