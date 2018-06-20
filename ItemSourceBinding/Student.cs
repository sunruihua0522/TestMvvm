using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemSourceBinding
{
    public class Student : INotifyPropertyChanged
    {
        private string id;
        private int age;
        private string name;
        public string Name { set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name")); } get { return name; } }
        public int Age { set { age = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age")); } get { return age; } }
        public string ID { set { id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID")); } get { return id; } }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
