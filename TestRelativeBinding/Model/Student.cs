using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRelativeBinding.Model
{
    public class Student : INotifyPropertyChanged
    {
        private string _name="";
        private string _id="";

        public string Name
        {
            get { return _name; }
            set { _name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name")); }
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID")); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
