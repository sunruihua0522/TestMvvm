using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDataProviderBinding
{
    public class Calu
    {
        public string Add(string a, string b)
        {
            double.TryParse(a,out double x);
            double.TryParse(b, out double y);
            Console.WriteLine("String---------");
            return (x + y).ToString();
        }
        public string Add(double a, double b)
        {
            Console.WriteLine("Double---------");
            return (a*b).ToString();
        }
    }
}
