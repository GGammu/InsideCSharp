using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ImpISerialApp
{
    [Serializable]
    public class Insect : ISerializable
    {
        private string name;
        private int id;

        public Insect() { }

        public Insect(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        private Insect(SerializationInfo s, StreamingContext c)
        {
            name = s.GetString("CommonName");
            id = s.GetInt32("ID#");
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", name, id);
        }

        public virtual void GetObjectData(SerializationInfo s, StreamingContext c)
        {
            s.AddValue("CommonName", name);
            s.AddValue("ID#", id);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Insect i = new Insect("Meadow Brown", 12);
            Stream s = File.Create("Insect.bin");
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, i);
            s.Seek(0, SeekOrigin.Begin);
            Insect j = (Insect)b.Deserialize(s);
            s.Close();
            Console.WriteLine(j);
            Console.ReadLine();
        }
    }
}
