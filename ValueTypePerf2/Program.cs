using System;
using System.Collections;

namespace ValueTypePerf2
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
            onlineUsers[0] = new User("Tom Arche");
            onlineUsers[1] = new User("Krista Crawley");
            onlineUsers[2] = new User("Emma Murdoch");
        }

        public IEnumerator GetEnumerator()
        {
            return new DBEnumerator(onlineUsers);
        }

        class DBEnumerator:IEnumerator
        {
            const string INVALID_RECORD = "Use MoveNext before calling Current";
            User[] onlineUsers = new User[3];
            int index;

            public DBEnumerator(User[] onlineUsers)
            {
                for (int i = 0; i < onlineUsers.Length; i++)
                    this.onlineUsers[i] = onlineUsers[i];

                Reset();
            }

            public object Current
            {
                get {
                    if (-1 == index)
                        throw new InvalidOperationException(INVALID_RECORD);
                    if (index < onlineUsers.Length)
                        return onlineUsers[index];
                    else
                        return null;
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

            IEnumerator e = (IEnumerator)db.GetEnumerator();
            while (e.MoveNext())
            {
                User user = (User)e.Current;
                Console.WriteLine("User={0}", user.Name);
            }

            Console.ReadLine();
        }
    }
}
