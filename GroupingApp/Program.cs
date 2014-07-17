using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GroupingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex r = new Regex("(i(n))g");
            Match m = r.Match("Matching");
            GroupCollection gc = m.Groups;

            Console.WriteLine("Found {0} Groups", gc.Count);

            for (int i = 0; i < gc.Count; i++)
            {
                Group g = gc[i];
                Console.WriteLine("Found '{0}' at position {1}", g.Value, g.Index);
            }

            Console.WriteLine("\n");

            for (int i = 0; i < gc.Count; i++)
            {
                CaptureCollection cc = gc[i].Captures;

                for (int j = 0; j < cc.Count; j++)
                {
                    Capture cap = cc[j];
                    Console.WriteLine("Found '{0}' at position {1}", cap.Value, cap.Index);
                }
            }

            Console.WriteLine("\n");

            Regex q = new Regex("(?<something>\\w+):(?<another>\\w+)");
            Match n = q.Match("Salary:123456");

            Console.WriteLine("{0} = {1}", n.Groups["something"].Value, n.Groups["another"].Value);

            Console.ReadLine();
        }
    }
}
