using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RethrowExample
{
    class Database
    {
        Stream data;

        public bool OpenDb()
        {
            try
            {
                data = new FileStream("C:\\db.dat", FileMode.Open);
            }
            catch (Exception e )
            {
                Console.WriteLine("[Database.OpenDb] Caught exception of type {0}",
                    e.GetType());

                Console.WriteLine("[Database.OepnDb] Calling LogError method...");

                LogError(e.Message);

                Console.WriteLine("[Database.OpenDb] Rethrowing exception to caller...");
                throw;
            }

            return true;
        }

        protected void LogError(string error)
        {
            Console.WriteLine("[Database.LogError] Logging '{0}'", error);
        }

        public bool LogIn(string userName, string password)
        {
            return true;
        }
    }
}
