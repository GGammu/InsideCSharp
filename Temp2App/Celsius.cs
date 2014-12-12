using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp2App
{
    class Celsius : Temperature
    {
        public Celsius(float temp) : base(temp) { }

        public static implicit operator Celsius(float temp)
        {
            return new Celsius(temp);
        }

        public static implicit operator Celsius(Fahrenheit f)
        {
            return new Celsius(f.Temp);
        }
        
        public static implicit operator float(Celsius c)
        {
            return  (c.Temp - 32) / 9 * 5;
        }
    }
}
