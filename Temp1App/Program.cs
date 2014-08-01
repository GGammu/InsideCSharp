using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp1App
{
    struct Celsius
    {
        public float temp;

        public Celsius(float temp)
        {
            this.temp = temp;
        }

        public static implicit operator Celsius(float temp)
        {
            Celsius c;
            c = new Celsius(temp);
            return (c);
        }

        public static implicit operator float(Celsius c)
        {
            return (c.temp - 32) / 9 * 5;
        }
    }

    struct Fahrenheit
    {
        public float temp;

        public Fahrenheit(float temp)
        {
            this.temp = temp;
        }

        public static implicit operator Fahrenheit(float temp)
        {
            Fahrenheit f;
            f = new Fahrenheit(temp);
            return (f);
        }

        public static implicit operator float(Fahrenheit f)
        {
            return (f.temp * 9) / 5 + 32;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            float t;

            t = 98.6F;
            Console.WriteLine("Setting {0} type to {1}", t.GetType(), t);
            Console.WriteLine("CONVERSION OF {0} ({1}) TO cELSIUS = ", 
                t.GetType(), t);
            Console.WriteLine((Celsius)t);

            Console.WriteLine();

            t = 0F;
            Console.WriteLine("Settinig {0} type to {1}", t.GetType(), t);

        }
    }
}
