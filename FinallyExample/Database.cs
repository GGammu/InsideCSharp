using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinallyExample
{
    class Database
    {
        public Database()
        {
            isDbOpen = false;
        }

        protected Stream data;

        protected bool isDbOpen;

        public bool IsDbOpen
        {
            get { return isDbOpen; }
        }

        public bool OpenDb()
        {
            isDbOpen = true;
            return true;
        }

        public bool Login(string userName, string password)
        {
            if (OpenTable("USERS")) 
            {

            }
            return true;
        }

        public void CloseDb()
        {
            isDbOpen = false;
        }

        public bool OpenTable(string table)
        {
            Console.WriteLine("[Database.OpenTable] Throwing " +
                "exception to caller...");
            throw new MyExceptionClass("Table not found!");
        }

        protected void LogError(string error)
        {
            Console.WriteLine("[Database.LogError] Logging '{0}'", error);
        }
    }
}
