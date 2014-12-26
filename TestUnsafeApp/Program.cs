using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnsafeApp
{
    class Program
    {
        unsafe public static void Swap(int* pi, int* pj)
        {
            int tmp = *pi;
            *pi = *pj;
            *pj = tmp;
        }
        static void Main(string[] args)
        {
            int i = 3;
            int j = 4;
            Console.WriteLine("BEFORE: i = {0}, j = {1}", i, j);
            unsafe { Swap(&i, &j); }
            Console.WriteLine("AFTER:  i = {0}, j = {1}", i, j);
            Console.ReadLine();
        }
    }
}
