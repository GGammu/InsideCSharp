using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTraceTestApp
{
    class Program
    {
        public void Open(string fileName)
        {
            Lock (fileName) ;
        }

        private void Lock(string fileName)
        {
            Console.WriteLine("[StackTraceTestApp.Lock] Throwing exception");
            throw new Exception("Failed to acquire lock on file");
        }

        static void Main(string[] args)
        {
            Program test = new Program();

            try
            {
                Console.WriteLine("[Main] Opening file...");
                test.Open("c:\\test.txt");
                Console.WriteLine("[Main] File successfully opened");
            }
            catch (Exception e)
            {
                Console.WriteLine("[Main] Caught exception '{0}'", e.Message);
                Console.WriteLine("[Main] Dumping trace informatio for exception...");
                Console.WriteLine(e.StackTrace);
            }

            Console.ReadLine();
        }
    }
}
