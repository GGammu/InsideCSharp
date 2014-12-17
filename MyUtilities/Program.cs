using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtilities
{
    public class AssemblyUtils
    {
        public static string GetAssemblyName(string[] args)
        {
            string assemblyName;
            if (0 == args.Length)
            {
                Process p = Process.GetCurrentProcess();
                assemblyName = p.ProcessName + ".exe";
            }
            else
            {
                assemblyName = args[0];
            }
            return assemblyName;
        }
    }
}
