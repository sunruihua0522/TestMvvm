using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DependencyProperty
{
    public class Student : DependencyObject
    {       
        public static readonly System.Windows.DependencyProperty NameProperty = System.Windows.DependencyProperty.Register("Name", typeof(string), typeof(Student));
        public string Name
        {
            set { SetValue(NameProperty, value); }
            get { return GetValue(NameProperty).ToString(); }
        }
    }
}
