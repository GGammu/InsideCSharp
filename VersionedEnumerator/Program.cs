using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace VersionedEnumerator
{
    class User
    {
        public User(string name) { this.name = name; }
        private string name;
        public string Name { get { return name; } }
    }

    class DBManager : IEnumerable
    {
        ArrayList onlineUsers = new ArrayList();

        public DBManager()
        {
            onlineUsers.Add(new User("Tom Archer"));
            onlineUsers.Add(new User("Krista Crawley"));
            onlineUsers.Add(new User("Emma Murdoch"));
        }

        static int version = 0;
        public static int Version { get { return version; } }

        public void AddItem(string userName)
        {
            version++;
            onlineUsers.Add(new User(userName));
        } 

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(version, onlineUsers);
        }

        class Enumerator : IEnumerator
        {
            const string INVALID_RECORD = "Use MoveNext before calling Current";
            const string DATA_OUT_OF_SYNC = "Data out of sync. Need to reacquire enumerator";

            ArrayList onlineUsers = new ArrayList();

            int version = 0;

            public Enumerator(int version, ArrayList onlineUsers)
            {
                foreach (User user in onlineUsers)
                {
                    this.version = version;
                    this.onlineUsers.Add(user);
                }

                Reset();
            }

            int index;

            public object Current
            {
                get
                {
                    if (-1 == index)
                    {
                        throw new NotImplementedException(INVALID_RECORD);
                    }

                    if (index < onlineUsers.Count)
                        return onlineUsers[index];
                    else
                        return null;
                }
            }

            public bool MoveNext()
            {
                CheckVersion();
                return (++index < onlineUsers.Count);
            }

            private void CheckVersion()
            {
                throw new NotImplementedException();
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
            Console.WriteLine("[Main] Enumerating currently " +
                "logged in users...");

            //IEnumerator e = db.GetEnumerator();

            //while (e.MoveNext())
            //{
            //    User user = (User)e.Current;
            //    Console.WriteLine("User={0}", user.Name);
            //}

            foreach (User user in db)
            {
                Console.WriteLine("User={0}", user.Name);
            }

            Console.ReadLine();


        }
    }
}
