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
using Thorlabs.TLPM_32.Interop;
namespace TestVisa
{
    public partial class Form1 : Form
    {
        private TLPM tlpm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HandleRef Instrument_Handle = new HandleRef();
            TLPM searchDevice = new TLPM(Instrument_Handle.Handle);
            uint count = 0;
            string firstPowermeterFound = "";
            try
            {
                int pInvokeResult = searchDevice.findRsrc(out count);

                if (count > 0)
                {
                    StringBuilder descr = new StringBuilder(1024);

                    searchDevice.getRsrcName(0, descr);

                    firstPowermeterFound = descr.ToString();
                }
            }
            catch(Exception ex)
            {

            }
            if (count == 0)
            {
                searchDevice.Dispose();
                return;
            }
            tlpm = new TLPM(firstPowermeterFound, false, false);
            //tlpm = new TLPM("USB0::0x1313::0x8072::P2010125::INSTR", false, false);  //  For valid Ressource_Name see NI-Visa documentation.
            double powerValue;
            int err = tlpm.measPower(out powerValue);
   

        }
    }
}
