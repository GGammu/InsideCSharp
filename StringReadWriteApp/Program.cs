using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StringReadWriteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriter w = new StringWriter();
            w.WriteLine("Sing a song of {0} pence", 6);
            string s = "A pocket full of rye";
            w.Write(s);
            w.Write(w.NewLine);
            w.Write(string.Format(4 + " and " + 20 + " blackbirds"));
            w.Write(new StringBuilder(" baked in a pie"));
            w.WriteLine();
            Console.WriteLine(w);

            StringBuilder sb = w.GetStringBuilder();
            int i = sb.Length;
            sb.Append("The birds began to sing");
            sb.Insert(i, "when the pie was opened\n");
            sb.AppendFormat("\nWasn't that a {0} to set before the king", "dainty dish");
            Console.WriteLine(w);

            Console.WriteLine();
            StringReader r = new StringReader(w.ToString());
            string t = r.ReadLine();
            Console.WriteLine(t);
            Console.Write((char)r.Read());
            char[] ca = new char[37];
            r.Read(ca, 0, 19);
            Console.Write(ca);
            Console.WriteLine(r.ReadToEnd());
            
            r.Close();
            w.Close();
            Console.ReadLine();
        }
    }
}
