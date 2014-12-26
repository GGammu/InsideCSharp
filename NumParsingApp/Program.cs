using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumParsingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = int.Parse("12345");
            Console.WriteLine("i = {0}", i);

            int j = Int32.Parse("12345");
            Console.WriteLine("j = {0}", j);

            double d = double.Parse("1.2345E+6");
            Console.WriteLine("d = {0}", d);

            string s = i.ToString();
            Console.WriteLine("s = {0}", s);

            string t = " -1,234,567.890";
            //double g = double.Parse(t);
            //Console.WriteLine("g = {0}", g);

            double g = double.Parse(t, NumberStyles.AllowLeadingSign |
                NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowThousands |
                NumberStyles.AllowLeadingWhite |
                NumberStyles.AllowTrailingWhite);
            Console.WriteLine("g = {0:f}", g);

            string u = "₤ -1,234,567.890";
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencySymbol = "₤";
            double h = double.Parse(u, NumberStyles.Any, ni);
            Console.WriteLine("h = {0:f}", h);

            int k = 12345;
            CultureInfo us = new CultureInfo("en-US");
            string v = k.ToString("c", us);
            Console.WriteLine(v);

            CultureInfo dk = new CultureInfo("da-DK");
            string w = k.ToString("c", dk);
            Console.WriteLine(w);

            Console.ReadLine();
        }
    }
}
