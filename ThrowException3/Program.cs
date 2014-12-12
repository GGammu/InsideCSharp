using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrowException3
{
    class Program
    {
        class FileOps
        {
            public void FileOpen(string fileName)
            {
                throw new Exception("Oh bother");
            }

            public void FileRead()
            {

            }
        }

        static void Main(string[] args)
        {
            try
            {
                FileOps fileOps = new FileOps();

                fileOps.FileOpen("C:\\test.txt");
                fileOps.FileRead();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
