using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadWriteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream s = new FileStream("Bar.txt", FileMode.Create);
            //StreamWriter w = new StreamWriter(s);
            StreamWriter w = new StreamWriter(s, System.Text.Encoding.BigEndianUnicode);
            w.Write("Hello World");
            w.Close();

            s = new FileStream("Bar.txt", FileMode.Open);
            StreamReader r = new StreamReader(s);
            string t;

            while ((t = r.ReadLine()) != null)
            {
                Console.WriteLine(t);
            }

            w.Close();

            Console.ReadLine();
        }
    }
}
