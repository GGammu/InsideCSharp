using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace GetAssemblyInfoApp
{
    class Attr : System.Attribute { }
    enum RGB
    {
        red = 0xFF0000,
        green = 0x00FF00,
        blue = 0x0000FF
    }
    class BaseClass
    {
        static readonly string Infinity;
        static BaseClass()
        {
            Infinity = "0/1";
        }
        protected BaseClass(string s) { }
    }
    class DerivedClass : BaseClass
    {
        DerivedClass() : base("test") { }
    }
    struct Point
    {
        int x;
        int y;
    }
    class Program
    {
        protected static Assembly GetAssembly(string[] args)
        {
            Assembly assembly;
            if (0 == args.Length)
            {
                assembly = Assembly.GetExecutingAssembly();
            }
            else
            {
                assembly = Assembly.LoadFrom(args[0]);
            }
            return assembly;
        }
        static void Main(string[] args)
        {
            Assembly assembly = GetAssembly(args);
            if (null != assembly)
                Console.WriteLine("Loading tyhpe info for {0}", assembly);
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Console.WriteLine("\nType: {0}", type);
                BindingFlags bf = BindingFlags.DeclaredOnly |
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.Static;
                foreach (MemberInfo member in type.GetMembers(bf))
                {
                    Console.WriteLine("\tMember: {0}", member);
                }
            }
            Console.ReadLine();
        }
    }
}
