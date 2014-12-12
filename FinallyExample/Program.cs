using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Main] Instantiating Database object");

            Database db = new Database();

            try
            {
                Console.WriteLine("[Main] Opening database...");
                if (db.OpenDb())
                {
                    Console.WriteLine("[Main] Successfully opened database");
                    Console.WriteLine("[Main] Loggin into database...");

                    if (db.Login("Tom", "password"))
                    {
                        Console.WriteLine("[Main] Successfully logged into " +
                            "database");
                    }
                }
            }
            catch (MyExceptionClass e)
            {
                Console.WriteLine("[Main] Caught exception : '{0}'", e.Message);
            }
            finally
            {
                if (db.IsDbOpen)
                {
                    Console.WriteLine("[Main] Closing database");
                    db.CloseDb();
                }
                Console.ReadLine();
            }
        }
    }
}
