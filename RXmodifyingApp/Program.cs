using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RXmodifyingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "   leading";
            string e = "^\\s+";
            string r;
            //Regex rx = new Regex(e);
            //string r = rx.Replace(s, "");
            //Console.WriteLine("Strip leading space:{0}", r);

            //string r = Regex.Replace(s, e, "");
            //Console.WriteLine("Strip leading space:{0}", r);

            s = "trailing   ";
            e = @"\s+$";
            r = Regex.Replace(s, e, "");
            Console.WriteLine("Strip trailing space: {0}", r);
            Console.WriteLine();

            s = @"C:\Documents and  Settings\user1\Desktop\";
            r = Regex.Replace(s, @"\\user1\\", @"\user2\");
            Console.WriteLine("Modify path:\n\t{0}\n\t{1}", s, r);
            Console.WriteLine();

            s = @"C:\foo\bar\file.txt";
            e = @"^.*\\";
            r = Regex.Replace(s, e, "");
            Console.WriteLine("Strip path from filename: {0}", r);
            Console.WriteLine();

            s = "03/16/57";
            e = "(?<mm>\\d{1,2})/(?<dd>\\d{1,2})/(?<yy>\\d{1,2})";
            string e2 = "${dd}-${mm}-${yy}";
            r = Regex.Replace(s, e, e2);
            Console.WriteLine("Change date format from {0} to {1}", s, r);
            Console.WriteLine();

            s = @"<html>
                <a href=""first.htm"">first text</a>
                <br>loads of other stuff
                <a href=""second.htm"">second text</a>
                <p>more<a href=""third.htm"">third text</a>
                </html>";
            e = @"<a[^>]*href\s*=\s[""']?([^'"">]+)['""]?>";
            MatchCollection mc = Regex.Matches(s, e);
            foreach (Match mm in mc)
            {
                Console.WriteLine("HTML links: {0}", mm);
            }

            Console.ReadLine();
        }
    }
}
