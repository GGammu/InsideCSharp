using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CombinedEnumerator
{
    class User
    {
        public User(string name) { this.name = name; }

        string name;

        public string Name { get { return name; } }   
    }

    class DBManager:IEnumerable, IEnumerator
    {
        const string INVALID_RECORD = "Use MoveNext before calling current";

        ArrayList onlineUsers = new ArrayList();

        public DBManager()
        {
            onlineUsers.Add(new User("Tom Archer"));
            onlineUsers.Add(new User("Krista Crawley"));
            onlineUsers.Add(new User("Emma Murdoch"));
        }

        public object Current
        {
            get
            {
                if (-1 == index)
                    throw new InvalidOperationException(INVALID_RECORD);

                if (index < onlineUsers.Count)
                    return onlineUsers[index];
                else
                    return null;
            }
        }

        int index;
        public bool MoveNext()
        {
            return (++index < onlineUsers.Count);
        }

        public void Reset()
        {
            index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DBManager db = new DBManager();

            foreach (User user in db)
            {
                Console.WriteLine("User={0}", user.Name);
            }

            Console.ReadLine();
        }
    }
}
