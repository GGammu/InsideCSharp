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
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
