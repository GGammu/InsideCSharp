using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenToCatchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Table table = new Table();

                Console.WriteLine("[Main] Attempting to add " +
                    "a new record to our fake table...");

                table.AddRecord("This would contain our data");
            }
            catch (Exception e)
            {
                Console.WriteLine("[Main] Exception caught '{0}'", e.Message);
            }

            Console.ReadLine();
        }
    }
}
