using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressTest
{
    public partial class Form1 : Form
    {
        private ValueChangeEventArgs ValueArgs = new ValueChangeEventArgs();
        private IProgress<EventArgs> progress = null;
        private int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_progressTest_Click(object sender, EventArgs e)
        {
            progress=new Progress<EventArgs>(DoUpdate);
            Task t = new Task(()=>ThreadFunc(progress));          
            t.Start();
        }
        private void ThreadFunc(IProgress<EventArgs> progress)
        {
            while (i++ < 100)
            {
                ValueArgs.strVaue = i.ToString();
                progress.Report(ValueArgs);
                Thread.Sleep(100);
            }
        }
        private void DoUpdate(EventArgs agrs)
        {
            label1.Text = (agrs as ValueChangeEventArgs).strVaue;
        }

    }
}
