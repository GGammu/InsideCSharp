using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SplitRegExApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "Once Upon A Time In America";

            //char[] seps = new char[] { ' ' };
            //foreach (string ss in s.Split(seps))
            //{
            //    Console.WriteLine(ss);
            //}

            //Regex r = new Regex(" ");
            //foreach (string ss in r.Split(s))
            //{
            //    Console.WriteLine(ss);
            //}

            //string t = "Once,Upon:A/Time\\In\'America";

            //char[] seps = new char[] { ' ', ',', ':', '/', '\\', '\'' };
            //foreach (string ss in t.Split(seps))
            //{
            //    Console.WriteLine(ss);
            //}

            //Regex r = new Regex(@" |,|/|\\|\'");
            //foreach (string ss in r.Split(t))
            //{
            //    Console.WriteLine(ss);
            //}

            //string u = "Once Upon A Time In     America";

            //Regex p = new Regex(" ");

            //foreach (string ss in p.Split(u))
            //{
            //    if (ss.Length>0)
            //    {
            //        Console.WriteLine(ss);
            //    }
            //}

            //string v = "Once Upon A Time In         America";
            //Regex o = new Regex(@"[ ]+");
            //foreach (string ss in o.Split(v))
            //{
            //    Console.WriteLine(ss);
            //}

            string x = "Once Upon A Time In America";
            Regex m = new Regex("( )");
            foreach (string ss in m.Split(x))
            {
                Console.WriteLine(ss);
            }

            Console.ReadLine();

        }
    }
}
