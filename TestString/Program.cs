using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestString
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "ABC";
            string b = null;
            string c = a;
            c = "Hello";
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
