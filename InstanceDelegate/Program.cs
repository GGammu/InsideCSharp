using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InstanceDelegate
{
    class DBConnection
    {
        protected static int NextConnectionNbr = 1;

        protected string connectionName;
        public string ConnectionName
        {
            get
            {
                return connectionName;
            }
        }

        public DBConnection()
        {
            connectionName = "Database connection " 
                + DBConnection.NextConnectionNbr++;
        }
    }

    class DBManager
    {
        protected ArrayList activeConnections;

        public DBManager()
        {
            activeConnections = new ArrayList();
            for (int i = 0; i < 6; i++)
            {
                activeConnections.Add(new DBConnection());
            }
        }

        public delegate void EnumConnectionsCallBack(DBConnection connection);

        public void EnumConnections(EnumConnectionsCallBack callback)
        {
            foreach (DBConnection connection in activeConnections)
            {
                callback(connection);
            }
        }
    }
    class Program
    {
        public static void PrintConnections(DBConnection connection) 
        {
            Console.WriteLine("[InstanceDelegate.PrintConections] {0}",
                connection.ConnectionName);
        }
        static void Main(string[] args)
        {
            DBManager dbManager = new DBManager();

            Console.WriteLine("[Main] Instantiating the deledate method");
            DBManager.EnumConnectionsCallBack printConnections =
                new DBManager.EnumConnectionsCallBack(PrintConnections);

            Console.WriteLine("[Main] Calling EnumConnections " +
                "- passing the delegate");
            dbManager.EnumConnections(printConnections);

            Console.ReadLine();
        }
    }
}
