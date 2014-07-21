using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RXassemblyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "123.45.67.89";
            string e = @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                @"([01]?\d\d?|2[0-4]\d|25[0-5])";

            Match m = Regex.Match(s, e);
            Console.WriteLine("IP Address: {0}", m);
            for (int i = 1; i < m.Groups.Count; i++)
            {
                Console.WriteLine("\tGroup{0}={1}", i, m.Groups[i]);
            }
            Console.ReadLine();
        }
    }
}
