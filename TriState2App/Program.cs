using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TriState2App
{
    class TriState
    {
        public enum TriStateValue
        {
            Null = -1,
            False = 0,
            True = 1
        }

        protected TriStateValue value;

        public TriState(TriStateValue value)
        {
            this.value = value;
        }

        public static explicit operator bool(TriState triState)
        {
            return (triState.value == TriStateValue.True ? true : false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Instanting a TriState object " + 
                "as TriState.TriStateValue.True");

            TriState t1 = new TriState(TriState.TriStateValue.True);
            bool b1 = (bool)t1;
            Console.WriteLine("TriState object converted to {0}", b1);

            Console.WriteLine("Instanting a TriState object " +
                "as TriState.TriStateValue.False");

            TriState t2 = new TriState(TriState.TriStateValue.False);
            bool b2 = (bool)t2;
            Console.WriteLine("TriState object converted to {0}", b2);

            Console.ReadLine();
        }
    }
}
