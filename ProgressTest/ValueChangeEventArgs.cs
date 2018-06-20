using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTest
{
    class ValueChangeEventArgs : EventArgs
    {
        public string strVaue { get; set; }
        public ValueChangeEventArgs()
        {
            strVaue = "";
        }
    }
}
