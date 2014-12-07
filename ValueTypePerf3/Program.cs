using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypePerf3
{
    struct User
    {
        public User(string name) { this.name = name; }
        string name;
        public string Name { get { return name; } }
    }

    class DBManager : IEnumerable
    {
        User[] onlineUsers = new User[3];

        public DBManager()
        {
            onlineUsers[0] = new User("Tom Archer");
            onlineUsers[1] = new User("Krista Crawley");
            onlineUsers[2] = new User("Emma Murdoch");
        }

        public DBEnumerator GetEnumerator()
        {
            return new DBEnumerator(onlineUsers);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class DBEnumerator : IEnumerator
        {
            const string INVALID_RECORD = "Use MoveNext before calling Current";
            User[] onlineUsers = new User[3];
            int index;

            public DBEnumerator(User[] onlineUsers)
            {
                for (int i = 0; i < onlineUsers.Length; i++)
                {
                    this.onlineUsers[i] = onlineUsers[i];
                    Reset();
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public object Current
            {
                get
                {
                    if (-1 == index || index >= onlineUsers.Length)
                        throw new InvalidOperationException(INVALID_RECORD);
                    return onlineUsers[index];
                }
            }

            public bool MoveNext()
            {
                return (++index < onlineUsers.Length);
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DBManager db = new DBManager();

            Console.WriteLine("[Main] Enumerating currently logged in users...");
            DBManager.DBEnumerator e = (DBManager.DBEnumerator)db.GetEnumerator();

            while (e.MoveNext())
            {
                User user = (User)e.Current;
                Console.WriteLine("User={0}", user.Name);
            }

            Console.ReadLine();
        }
    }
}
