using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_CTS
{
    class Program
    {
        private static CancellationTokenSource cts = new CancellationTokenSource();
        public static void Main(string[] args)
        {
            Task task1 = new Task(() => A("AAAAAAA") , cts.Token);
            task1.Start();
            Task task2 = new Task(() => A("BBBBBBBBB"), cts.Token);
            task2.Start();

            Console.ReadKey();
            cts.Cancel();
            Console.ReadKey();
        }
        private static void A(string str)
        {
            while (!cts.IsCancellationRequested)
            {
                Console.WriteLine(str);
                Thread.Sleep(5000);
               
            }
        }
    }
}
