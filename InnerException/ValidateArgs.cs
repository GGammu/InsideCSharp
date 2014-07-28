using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace InnerException
{
    class ValidateArgs
    {
        protected bool IsValidParam(string value)
        {
            bool success = false;

            if (value.Length == 3)
            {
                char c1 = value[0];

                if (char.IsNumber(c1))
                {
                    char c2 = value[2];

                    if (char.IsNumber(c2))
                    {
                        if (value[1] == '.')
                        {
                            success = true;
                        }
                    }
                }
            }
            return success;
        }

        public void DoWork(string value)
        {
            if (!IsValidParam(value))
            {
                throw new Exception("",
                    new FormatException("Invalid parameter specified"));
            }
            Console.WriteLine("Work done with '{0}'", value);
        }
    }
}
