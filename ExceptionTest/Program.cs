using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                f2a().ContinueWith(t => Console.WriteLine(t.Exception.Flatten()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        static async Task f2a()
        {
            try
            {
                await Task.Run(() => div(2, 3));
            }
            catch(Exception e)
            {

            }
        }
        static  double div(double a,double b)
        {
            throw new Exception("JJJJ");
        }
    }
}
