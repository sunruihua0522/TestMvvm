using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseCPPCharXIng
{
    public class Program
    {

        static void Main(string[] args)
        {

            //StringBuilder sb = new StringBuilder();
            //bool b=GetResultCharXing(0,sb);
            //string str = sb.ToString();
            //b= GetResultCharXing(1, sb);
            //str = sb.ToString();


            //StringBuilder refSb = new StringBuilder();
            //string a = "TomCat";
            //string b = "aa";    //不能为空字符串
            //string c = "cc";    //不能为空字符串
            //IntPtr[] pts = new IntPtr[2];
            //pts[1] = Marshal.StringToHGlobalAnsi(c);
            //pts[0] = Marshal.StringToHGlobalAnsi(b);
            //GetResultCharXingXing(a,pts);
            //string s = Marshal.PtrToStringAnsi(pts[0]);
            //string ss = Marshal.PtrToStringAnsi(pts[1]);
            ////MessageBox.Show($"S为{s}----ss为{ss}");
            //Marshal.FreeHGlobal(pts[0]);
            //Marshal.FreeHGlobal(pts[1]);
        }
        [DllImport("CPPCharXing.dll",EntryPoint ="GetResult", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetResultCharXing(int x,StringBuilder sb);

        [DllImport("CPPCharXingXing.dll", EntryPoint = "GetResult", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetResultCharXingXing(string a, IntPtr[] refSb);

    }
}
