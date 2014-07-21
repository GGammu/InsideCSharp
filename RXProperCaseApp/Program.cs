using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RXProperCaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "the qUEEn wAs in HER parLOr";
            Console.WriteLine("Initial String:\t{0}", s);

            s = s.ToLower();
            string e = "\\w+|\\W+";
            string sProper = "";

            foreach (Match m in Regex.Matches(s, e))
	        {
                sProper += char.ToUpper(m.Value[0]) + m.Value.Substring(1, m.Length -1);
	        }

            Console.WriteLine("ProperCase:\t{0}", sProper);

            Console.ReadLine();
        }
    }
}
