using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeOfApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Apple);
            string className = t.ToString();

            Console.WriteLine("\nInformation on the class {0}", className);

            Console.WriteLine("\n{0} methods", className);
            Console.WriteLine("---------------------------");

            MethodInfo[] methods = t.GetMethods();

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.ToString());
            }
            
            Console.WriteLine("\nAll {0} members", className);
            Console.WriteLine("--------------------------");

            MemberInfo[] allMembers = t.GetMembers();
            foreach (MemberInfo member in allMembers)
            {
                Console.WriteLine(member.ToString());
            }

            Console.ReadLine();
        }
    }
}
