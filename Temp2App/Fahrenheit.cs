using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp2App
{
    class Fahrenheit : Temperature
    {
        public Fahrenheit(float temp) : base(temp) { }

        public static implicit operator Fahrenheit(float temp)
        {
            return new Fahrenheit(temp);
        }

        public static implicit operator Fahrenheit(Celsius c)
        {
            return new Fahrenheit(c.Temp);
        }

        public static implicit operator float(Fahrenheit f)
        {
            return (f.Temp * 9) / 5 + 32;
        }
    }
}
