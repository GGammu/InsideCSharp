using System;
using System.Collections;

namespace ValueTypePerf1
{
    struct User
    {
        public User(string name) { this.name = name; }
        string name;
        public string Name { get { return name; } }
    }

    class DBManger:IEnumerable
    {
        ArrayList onlineUsers = new ArrayList();

        public DBManger()
        {
            onlineUsers.Add(new User("Tom Archer"));
            onlineUsers.Add(new User("Krista Crawley"));
            onlineUsers.Add(new User("Emma Murdoch"));
        }

        public IEnumerator GetEnumerator()
        {
            return new DBEnumerator(onlineUsers);
        }

        class DBEnumerator : IEnumerator
        {
            const string INVALID_RECORD = "Use MoveNext before calling Current";

            ArrayList onlineUsers = new ArrayList();
            int index;

            public DBEnumerator(ArrayList onlineUsers)
            {
                foreach (User user in onlineUsers)
                {
                    this.onlineUsers.Add(user);
                }
                Reset();
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
            DBManger db = new DBManger();

            Console.WriteLine("[Main] Enumerating currently logged in users...");

            IEnumerator e = db.GetEnumerator();

            while (e.MoveNext())
            {
                User user = (User)e.Current;
                Console.WriteLine("User={0}", user.Name);
            }

            Console.ReadLine();
        }
    }
}
