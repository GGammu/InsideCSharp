using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sa = Directory.GetLogicalDrives();
            Console.WriteLine("Logical Drives: ");
            foreach (string s in sa)
            {
                Console.Write("{0, -4}", s);
            }

            //DirectoryInfo dir = new DirectoryInfo("Foo");

            //if (false == dir.Exists)
            //{
            //    dir.Create();
            //}

            //DirectoryInfo dis = dir.CreateSubdirectory("Bar");
            //dis.Attributes |= FileAttributes.Hidden | FileAttributes.Archive;
            //Console.WriteLine("{0, -10}{1, -10}{2}",
            //    dis.Name, dis.Parent, dis.Attributes);
            //dis.Delete(true);
            //dir.Delete(true);
            //Directory.Delete(dir.Name, true);
            
            //DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            //Console.WriteLine("Current Dir: {0}", dir.FullName);
            
            //DirectoryInfo dir = new DirectoryInfo(".");
            //DirectoryInfo dir = new DirectoryInfo(@"c:\Windows");
            
            //foreach (FileInfo f in dir.GetFiles())
            //{
            //    Console.WriteLine("{0, -14}{1, 10}{2, 20}", 
            //        f.Name, f.Length, f.LastWriteTime);
            //}

            //Console.WriteLine("\n{0, -32}{1}", "Name", "LastWrieteTime");

            //foreach (DirectoryInfo d in dir.GetDirectories())
            //{
            //    Console.WriteLine("{0, -32}{1}", d.Name, d.LastWriteTime);
            //}
            
            Console.ReadLine();
        }
    }
}
