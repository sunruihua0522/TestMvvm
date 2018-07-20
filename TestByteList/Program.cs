using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestByteList
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] recv = new byte[] { 0x2a, 0xa2, 0x34, 0x76, 0x2a, 0xa2, 0x88, 0x99, 0x87, 0x99, 0x36, 0x73, 0x2a, 0xa2,0x2a };
            var a=recv.SkipWhile(value => value == 0x2a);
            int[] aa = SearchHeader(recv, new byte[] { 0x2a, 0xa2 },6);
            var list = recv.Skip(aa[0]).Take(6+2);
            foreach (var it in list)
                Console.WriteLine(it);
        }

        static int[] SearchHeader(byte[] arr,byte[] header)
        {
            int nLenArr = arr.Length;
            int nLenHeader = header.Length;

            List<int> ls = new List<int>();
            List<int> ll = new List<int>();
            for (int i = 0; i < nLenArr; i++)
            {
                if (arr[i] == header[0])
                {
                    ls.Add(i);
                }
            }
            foreach (var it in ls)
            {
                if (it < nLenArr - nLenHeader)
                {
                    bool b = true;
                    for (int i = 0; i < nLenHeader; i++)
                    {
                        b &= arr[it+i] == header[i];
                    }
                    if(b)
                        ll.Add(it);
                }
            }
            return ll.ToArray();
        }
        static int[] SearchHeader(byte[] arr, byte[] header,int subArrLen)
        {
            int nLenArr = arr.Length;
            int nLenHeader = header.Length;

            List<int> ls = new List<int>();
            List<int> ll = new List<int>();
            List<int> y = new List<int>();
            for (int i = 0; i < nLenArr; i++)
            {
                if (arr[i] == header[0])
                {
                    ls.Add(i);
                }
            }
            foreach (var it in ls)
            {
                if (it < nLenArr - nLenHeader)
                {
                    bool b = true;
                    for (int i = 0; i < nLenHeader; i++)
                    {
                        b &= arr[it + i] == header[i];
                    }
                    if (b)
                        ll.Add(it);
                }
            }
            for (int i = 0; i < ll.Count()-1; i++)
            {
                if (ll[i + 1] - ll[i] == subArrLen + nLenHeader)
                    y.Add(ll[i]);
            }
            return y.ToArray();
        }
    }
}
