using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StaticDelegate
{
    class DBConnection
    {
        protected static int NextConnectionNbr = 1;

        protected string connectionName;
        public string ConnectionName
        {
            get { return connectionName; }
        }

        public DBConnection()
        {
            connectionName = "Database Connection "
                + DBConnection.NextConnectionNbr++;
        }
    }

    class DBManger
    {
        protected ArrayList activeConnections;
        
        public DBManger()
        {
            activeConnections = new ArrayList();

            for (int i = 0; i < 6; i++)
            {
                activeConnections.Add(new DBConnection());
            }
        }

        public delegate void EnumConnectionsCallback(DBConnection connection);

        public void EnumConnections(EnumConnectionsCallback callback)
        {
            foreach (DBConnection connection in activeConnections)
            {
                callback(connection);
            }
        }
    }

    class Program
    {
        static DBManger.EnumConnectionsCallback printConnections
            = new DBManger.EnumConnectionsCallback(printConnections);

        public static void PrintConnections(DBConnection connection)
        {
            Console.WriteLine("[StaticDelegate.PrintConnections] {0}",
                connection.ConnectionName);
        }

        static void Main(string[] args)
        {
            DBManger dbManager = new DBManger();

            Console.WriteLine("[Main] Calling EnumConnections " +
                "- passing the delegate");
            dbManager.EnumConnections(printConnections);

            Console.ReadLine();
        }
    }
}
