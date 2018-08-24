using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask
{
    class Program
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            
            Task.Factory.StartNew(()=>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(i);
                }
            },cts.Token);
            Console.ReadKey();
            Console.WriteLine("Kill Task");
            cts.Cancel();
            Console.ReadKey();
        }
    }
}
