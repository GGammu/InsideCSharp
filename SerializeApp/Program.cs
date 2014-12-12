using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeApp
{
    [Serializable]
    public class Insect
    {
        private string name;
        private int id;

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
        static void Main(string[] args)
        {
            Insect i = new Insect("Meadow Brow", 12);
            Stream sw = File.Create("Insects.bin");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(sw, i);
            sw.Close();

            ArrayList box = new ArrayList();
            box.Add(new Insect("Marsh Fritillarry", 34));
            box.Add(new Insect("Speckled Wood", 56));
            box.Add(new Insect("Milkweed", 78));

            sw = File.Open("Insects.bin", FileMode.Append);
            bf.Serialize(sw, box);
            sw.Close();

            Stream sr = File.OpenRead("Insects.bin");
            Insect j = (Insect)bf.Deserialize(sr);
            Console.WriteLine(j);

            ArrayList bag = (ArrayList)bf.Deserialize(sr);
            sr.Close();

            foreach (Insect k in bag)
            {
                Console.WriteLine(k);
            }

            Console.ReadLine();
        }
    }
}
