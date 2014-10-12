using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp2App
{
    class Program
    {
        public static void DisplayTemp(Celsius Temp)
        {
            Console.Write("Conversion of {0} {1} to Fahrenheit = ",
                Temp.ToString(), Temp.Temp);
            Console.WriteLine("(Fahrenheit)Temp");
        }

        public static void DisplayTemp(Fahrenheit Temp)
        {
            Console.Write("Conversion of {0} {1} to Celsius = ",
                Temp.ToString(), Temp.Temp);
            Console.WriteLine("(Celsius)Temp");
        }

        static void Main(string[] args)
        {
            Fahrenheit f = new Fahrenheit(98.6F);
            DisplayTemp(f);

            Celsius c = new Celsius(0F);
            DisplayTemp(c);

            Console.ReadLine();
        }
    }
}
