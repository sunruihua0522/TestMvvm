using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsyncReturn
{
    class Program
    {
        static bool? bOk = null;
        static CancellationTokenSource cts = null;
        static void Main(string[] args)
        {
            Task t = new Task(()=> {
                
                Console.WriteLine("Run");
                GetResult(true);
                GetResult(true);
                GetResult(true);
                GetResult(true);
                Thread.Sleep(3000);
                cts.Cancel();
                cts.Cancel();
                cts.Cancel();
                cts.Cancel();
                cts.Cancel();
                cts.Cancel();
                Console.WriteLine("Cancle");
            });
            t.Start();
            Console.ReadKey();
        }

        static async void GetResult(bool bMonitor)
        {
            if (bMonitor)
            {
                if (cts == null)
                {
                    cts = new CancellationTokenSource();
                    await Task.Run(() =>
                    {
                        while (!cts.IsCancellationRequested)
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("Loops");
                        }
                    }, cts.Token);
                }
            }
            else
            {
                if (cts != null)
                {
                    cts.Cancel();
                }
                cts = null;
            }

        }
    }
}
