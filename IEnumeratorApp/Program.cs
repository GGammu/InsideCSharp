using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumeratorApp
{
    class User
    {
        public User(string name) { this.name = name; }
        private string name;
        public string Name { get {return name;} }
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

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(onlineUsers);
        }

        class Enumerator : IEnumerator
        {
            const string INVALID_RECORD = "Use MoveNext before calling Current";
            ArrayList onlineUsers = new ArrayList();

            public Enumerator(ArrayList onlineUsers)
            {
                foreach (User user in onlineUsers)
                {
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
                return (++index < onlineUsers.Count);
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
