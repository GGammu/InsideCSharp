using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutatorInterfaces
{
    interface IUserData
    {
        string Name { get; set; }
    }

    struct User :IUserData
    {
        public User(string name) { this.name = name; }
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    class DBManager
    {
        public DBManager() 
        {
            onlineUsers.Add(new User("Tom Archer"));
        }

        public ArrayList onlineUsers = new ArrayList();
    }

    class Program
    {
        static void Main(string[] args)
        {
            DBManager db = new DBManager();

            IUserData u = (IUserData)db.onlineUsers[0];

            Console.WriteLine(u.Name);
            u.Name = "NEW NAME";
            Console.WriteLine(u.Name);
            Console.ReadLine();
        }
    }
}
