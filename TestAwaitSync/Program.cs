using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAwaitSync
{
    class Program
    {
        static void Main(string[] args)
        {
            testc();
            Console.WriteLine("Main Start");

            while (true)
            {
                string str = Console.ReadLine();
                if ( str== "q")
                    break;
            }
        }
        private static async void tt()
        {
            int x = await testc();
        }

        private static async Task<int> testc()
        {
            int x = await Task<int>.Run(() => SimpleTest(34));
            Console.WriteLine(x);
            return x;
        }

        private static int SimpleTest(int m)
        {
            for (int i = 1; i < 6; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine("Async-----");
            }
            return m;
        }
    
    }
}
