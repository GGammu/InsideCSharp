using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamsIOApp
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buf1 = new Byte[] 
                { 76, 101, 116, 32, 116, 104, 101, 114, 101, 32, 
                98, 101, 32, 108, 105, 103, 104, 116 };

            //Stream s = new FileStream("Foo.txt", FileMode.Create);
            FileStream s = new FileStream("Foo.txt", FileMode.Create);
            s.Write(buf1, 0, buf1.Length);
            s.Close();

            s = new FileStream("Foo.txt", FileMode.Open);

            string str = "";

            if (s.CanRead)
            {
                for (int i = 0; (i = s.ReadByte()) != -1 ; i++)
                {
                    str += (char)i;
                }
            }

            s.Close();
            Console.WriteLine(str);

            byte[] buf2 = new Byte[] { 97, 112, 112, 108, 101, 115, 97, 117, 99, 101 };

            s = new FileStream("Foo.txt", FileMode.Open);
            Console.WriteLine("Length: {0}, Position: {1}", s.Length, s.Position);

            if (s.CanSeek)
            {
                s.Seek(13, SeekOrigin.Begin);
                Console.WriteLine("Position: {0}", s.Position);
                s.Write(buf2, 0, buf2.Length);
            }

            str = "";
            s.Seek(0, SeekOrigin.Begin);
            for (int i = 0; (i = s.ReadByte()) != -1; i++)
            {
                str += (char)i;
            }
            s.Close();
            Console.WriteLine(str);

            byte[] buf4 = new byte[] { 32, 97, 110, 100, 32, 112, 101, 97, 114, 115 };

            s = new FileStream("Foo.txt", FileMode.Append, FileAccess.Write);
            s.Write(buf4, 0, buf4.Length);
            s.Close();

            s = new FileStream("Foo.txt", FileMode.Open);
            str = "";
            for (int i = 0; (i = s.ReadByte()) != -1 ; i++)
            {
                str += (char)i;
            }

            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
