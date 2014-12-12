using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace TestPathApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = Process.GetCurrentProcess();
            ProcessModule pm = p.MainModule;
            string s = pm.ModuleName;

            Console.WriteLine(Path.GetFullPath(s));
            Console.WriteLine(Path.GetFileName(s));
            Console.WriteLine(Path.GetFileNameWithoutExtension(s));
            Console.WriteLine(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            Console.WriteLine(Path.GetPathRoot(Directory.GetCurrentDirectory()));
            Console.WriteLine(Path.GetTempPath());
            Console.WriteLine(Path.GetTempFileName());

            Console.ReadLine();
        }
    }
}
