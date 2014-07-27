using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Retry
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr;

            int attempts = 0;
            int maxAttempts = 3;

        GetFile:
            Console.Write("\n[Attempt #{0}] Specify file to open\read: ",
                attempts + 1);
        string fileName = Console.ReadLine();

        try
        {
            sr = new StreamReader(fileName);

            Console.WriteLine();

            string s;
            while (null != (s = sr.ReadLine()))
            {
                Console.WriteLine(s);
            }

            sr.Close();
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);

            if (++attempts < maxAttempts)
            {
                Console.Write("Do you want to select another file: ");
                string response = Console.ReadLine();
                response = response.ToUpper();
                if (response == "Y") 
                {
                    goto GetFile;
                }
            }
            else
            {
                Console.Write("You have exceeded the maximum retry limit ({0})", 
                    maxAttempts);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
        }
    }
}
