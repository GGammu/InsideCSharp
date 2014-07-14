using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeOfCustomTypesApp
{
    struct StructWithNoMembers
    {
        
    }

    struct StructWithMembers
    {
        short s;
        int i;
        long l;
        bool b;
    }

    struct CompositeStruct
    {
        StructWithNoMembers a;
        StructWithMembers b;
        StructWithNoMembers c;
    }
    class Program
    {
        unsafe static void Main(string[] args)
        {
            Console.WriteLine("sizeof StructWithNoMembers structure = {0}", 
                sizeof(StructWithNoMembers));

            Console.WriteLine("sizeof StructWithMemberes structure = {0}",
                sizeof(StructWithMembers));

            Console.WriteLine("sizeof CompositeStruct structure = {0}",
                sizeof(CompositeStruct));

            Console.ReadLine();
        }
    }
}
