using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinReadWriteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream s = new FileStream("Foo.txt", FileMode.Create);
            StreamWriter w = new StreamWriter(s);
            w.Write("Hello World");
            w.Write(123);
            w.Write(' ');
            w.Write(45.67);
            w.Close();
            s.Close();

            Stream t = new FileStream("Bar.dat", FileMode.Create);
            BinaryWriter b = new BinaryWriter(t);
            b.Write("Hello World");
            b.Write(123);
            b.Write(' ');
            b.Write(45.67);
            b.BaseStream.Position = 0;
            BinaryReader r = new BinaryReader(t);
            int i = 0;
            while (true)
            {
                i = b.BaseStream.ReadByte();
                if (-1 == i)
                {
                    Console.WriteLine();
                    break;
                }
                Console.Write("{0, -4}", i);
            }
            r.Close();
            b.Close();
            t.Close();

            Console.ReadLine();
        }
    }
}
