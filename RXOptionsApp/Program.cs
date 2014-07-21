using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RXOptionsApp
{
    class Program
    {
        public static void PrintMatches(Regex r)
        {
            Console.WriteLine();
            string s = "The KING Was In His Counting House";
            MatchCollection mc = r.Matches(s);
            for (int i = 0; i < mc.Count; i++)
            {
                Console.WriteLine("Found '{0}' at position {1}", mc[i].Value, mc[i].Index);
            }
        }
        static void Main(string[] args)
        {
            //Regex r = new Regex("in|In|IN|iN");
            //Regex r = new Regex("in", RegexOptions.IgnoreCase);
            //Regex r = new Regex("in", RegexOptions.IgnoreCase|RegexOptions.RightToLeft);
            Regex r = new Regex(@"in#this is the first pattern to match 
                |[aeiou]s# or any vowel followed by 's'", RegexOptions.IgnorePatternWhitespace);
            PrintMatches(r);
            Console.ReadLine();
        }
    }
}
