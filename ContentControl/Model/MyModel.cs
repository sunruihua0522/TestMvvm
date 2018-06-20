using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentControl.Model
{
    
    public class MyModel : INotifyPropertyChanged
    {
        public bool _selectUi1;
        public bool SelectUi1
        {
            get { return _selectUi1; }
            set { if (_selectUi1 != value) { _selectUi1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectUi1")); } }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
