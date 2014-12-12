using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DelegateProperty
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
        protected ArrayList activeAconnections;
        public DBManger()
        {
            activeAconnections = new ArrayList();
            for (int i = 0; i < 6; i++)
            {
                activeAconnections.Add(new DBConnection());
            }
        }

        public delegate void EnumConnectionsCallback(DBConnection connection);

        public void EnumConnections(EnumConnectionsCallback callback)
        {
            foreach (DBConnection connection in activeAconnections)
            {
                callback(connection);
            }
        }
    }

    class Program
    {
        void printConnections(DBConnection connection)
        {
            Console.WriteLine("[DelegateProperty.printConnections] "
                + "{0}", connection.ConnectionName);
        }

        public DBManger.EnumConnectionsCallback PrintConnections
        {
            get
            {
                return new DBManger.EnumConnectionsCallback(printConnections);
            }
        }
    
        static void Main(string[] args)
        {
            Program app = new Program();
            DBManger dbManager = new DBManger();

            Console.WriteLine("[Main] Calling EnumConnections - " +
                "passing the delegate");
            dbManager.EnumConnections(app.PrintConnections);

            Console.ReadLine();
        }
    }
}
