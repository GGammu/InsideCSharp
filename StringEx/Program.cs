using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "the qUEEn wAs in HER ParLor";

            Console.WriteLine("Initial String:\t{0}", s);

            string t = StringEx.ProperCase(s);
            Console.WriteLine("ProperCase:\t{0}", t);

            Console.ReadLine();
        }
    }
}
