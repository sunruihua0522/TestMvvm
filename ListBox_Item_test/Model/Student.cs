using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBox_Item_test.Model
{
    public class Student : INotifyPropertyChanged
    {
        private string _name;
        private int _age;
        private string _id;
        private int _index;
        public string Name { set { _name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name")); } get { return _name; }  }
        public int Age { set { _age = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age")); } get { return _age; } }
        public string ID { set { _id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID")); } get { return _id; } }
        public int Index { set { _index = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Index")); } get { return _index; } }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
