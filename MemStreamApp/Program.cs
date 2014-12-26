using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MemStreamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream m = new MemoryStream(64);
            Console.WriteLine("Lenth: {0}\tPosition: {1}\tCapacity: {2}",
                m.Length, m.Position, m.Capacity);

            for (int i = 0; i < 64; i++)
            {
                m.WriteByte((byte)i);
            }

            string s = "Foo";
            for (int i = 0; i < 3; i++)
            {
                m.WriteByte((byte)s[i]);
            }

            Console.WriteLine("Length: {0}\tPosition: {1}\tCapacity: {2}",
                m.Length, m.Position, m.Capacity);

            Console.WriteLine("\nContents:");
            byte[] ba = m.GetBuffer();

            foreach (byte b in ba)
            {
                Console.Write("{0,-3}", b);
            }

            FileStream fs = new FileStream("Goo.txt", FileMode.Create, FileAccess.Write);
            m.WriteTo(fs);
            fs.Close();
            m.Close();

            Console.ReadLine();
        }
    }
}
