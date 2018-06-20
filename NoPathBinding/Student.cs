using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPathBinding
{
    public class Student : INotifyPropertyChanged
    {
        private string name, id;
        private int age;
        public string Name { set { name=value; PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Name")); } get { return name; } }
        public string ID { set { id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID")); } get { return id; } }
        public int Age { set { age = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age")); } get { return age; } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
