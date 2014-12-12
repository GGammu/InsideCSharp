using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowExceptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("[Main] Attempting to open a comma delimited file..");

                CommaDelimitedFile file = new CommaDelimitedFile();
                file.Open("c:\\test.csv");

                Console.WriteLine("[Main] Open successful");

                string record = "";
                Console.WriteLine("[Main] Reading form file...");

                while (file.Read(record) == true)
                {
                    Console.WriteLine("[Main] record = {0}", record);
                }

                Console.WriteLine("[Main] Finished reading file");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
