using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WebPagesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "http://www.microsoft.com";
            Uri uri = new Uri(s);
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            Stream str = resp.GetResponseStream();
            StreamReader sr = new StreamReader(str);

            string t = sr.ReadToEnd();
            int i = t.IndexOf("<head>");
            int j = t.IndexOf("</head>");

            string u = t.Substring(i, j);
            Console.WriteLine(u);
            Console.ReadLine();
        }
    }
}
