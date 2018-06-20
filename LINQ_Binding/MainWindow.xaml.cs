using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINQ_Binding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Student> stuList = new List<Student>();
            stuList.Add(new Student() { ID = "1111", Age = 89, Name = "Tom" });
            stuList.Add(new Student() { ID = "222", Age = 23, Name = "Tony" });
            stuList.Add(new Student() { ID = "333", Age = 45, Name = "Lucy" });

            ListView1.ItemsSource = from stu in stuList where stu.Name.StartsWith("T") && stu.Name.EndsWith("y")  select stu;   
        }
    }
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
    }
}
