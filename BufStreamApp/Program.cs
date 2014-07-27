using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BufStreamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("Hoo.txt", 
                FileMode.Create, FileAccess.ReadWrite);

            BufferedStream bs = new BufferedStream(fs);
            Console.WriteLine("Length: {0}\tPosition: {1}", bs.Length, bs.Position);

            for (int i = 0; i < 64; i++)
            {
                bs.WriteByte((byte)i);
            }

            Console.WriteLine("Length: {0}\tPosition: {1}", bs.Length, bs.Position);

            Console.WriteLine("\nContents:");
            byte[] ba = new byte[bs.Length];
            bs.Position = 0;
            bs.Read(ba, 0, (int)bs.Length);
            foreach (byte b in ba)
            {
                Console.Write("{0, -3}", b);
            }

            string s = "Foo";
            for (int i = 0; i < 3; i++)
            {
                bs.WriteByte((byte)s[i]);
            }

            Console.WriteLine("Length: {0}\tPosition: {1}", bs.Length, bs.Position);
            for (int i = 0; i < (256-67) + 1; i++)
            {
                bs.WriteByte((byte)i);
            }

            Console.WriteLine("Length: {0}\tPosition: {1}", bs.Length, bs.Position);

            bs.Close();
            Console.ReadLine();
        }
    }
}
