using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml.Serialization;

namespace SerializeRawXMLApp
{
    //[Serializable]
    public class Insect
    {
        private string name;
        [XmlIgnore] 
        private int id;

        public Insect() { }

        public Insect(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", name, id);
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Insect i = new Insect("Meadow Brow", 12);
            XmlSerializer x = new XmlSerializer(typeof(Insect));
            Stream s = File.Create("AnInsect.xml");

            x.Serialize(s, i);
            s.Seek(0, SeekOrigin.Begin);
            Insect j = (Insect)x.Deserialize(s);
            s.Close();
            
            Console.WriteLine(j);
            Console.ReadLine();
        }
    }
}
