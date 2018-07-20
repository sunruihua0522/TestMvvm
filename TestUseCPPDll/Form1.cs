using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCliDll;
namespace TestUseCPPDll
{
    public partial class Form1 : Form
    {
        //[DllImport("TestCharCliOutDll.dll")]
        //[DllImport("MyDll.dll")]
        //public static extern bool GetResult(StringBuilder str);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void Foo()
        {

            MyCliDll.MyCliCLass c = new MyCliCLass();
            //string s = "Hellp";
         
        }

    }
}
