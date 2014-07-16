using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExApp
{
    class StringEx
    {
        public static string ProperCase(string s)
        {
            s = s.ToLower();
            string sProper = "";

            char[] seps = new char[] { ' ' };
            foreach (string ss in s.Split(seps))
            {
                sProper += char.ToUpper(ss[0]);
                sProper += (ss.Substring(1, ss.Length - 1) + ' ');
            }

            return sProper;
        }
    }
}
