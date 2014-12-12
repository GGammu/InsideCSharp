using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp2App
{
    class Temperature
    {
        protected float temp;

        public Temperature(float temp)
        {
            this.temp = temp;
        }

        public float Temp
        {
            get
            {
                return this.temp;
            }
        }
    }
}
