using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileFileInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Stream s = new FileStream("Bar.txt", FileMode.Create);
            //FileInfo f = new FileInfo("Bar.txt");
            //FileStream fs = f.Create();
            //StreamWriter w = new StreamWriter(fs);
            //w.Write("Hello World");
            //w.Close();
            ////s = new FileStream("Bar.txt", FileMode.Open);
            //fs = f.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            //StreamReader r = new StreamReader(fs);
            //string t;
            //while ((t = r.ReadLine()) != null)
            //{
            //    Console.WriteLine(t);
            //}
            //fs.Close();
            //f.Delete();

            //FileInfo f2 = new FileInfo("Bar.txt");
            //FileStream fs2 = File.Create("Bar.txt");
            //StreamWriter w2 = new StreamWriter(fs2);
            //w2.Write("Goodbye Mars");
            //w2.Close();
            //fs2 = File.Open("Bar.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            //StreamReader r2 = new StreamReader(fs2);
            //string t;
            //while ((t = r2.ReadLine()) != null)
            //{
            //    Console.WriteLine(t);
            //}
            //fs2.Close();
            //f2.Delete();

            FileInfo f3 = new FileInfo("Bar.txt");
            StreamWriter w3 = f3.CreateText();
            w3.Write("Farewell Pluto");
            w3.Close();
            StreamReader r3 = f3.OpenText();
            string t;
            while ((t = r3.ReadLine()) != null)
            {
                Console.WriteLine(t);
            }
            r3.Close();
            f3.Delete();

            Console.ReadLine();
        }
    }
}
