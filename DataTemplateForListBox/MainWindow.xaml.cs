using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataTemplateForListBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Student> stuList = new ObservableCollection<Student>();
        public ObservableCollection<Student> StuList { get { return stuList; } set { stuList = value; } }
        public MainWindow()
        {
           // DataContext = this;
            stuList.Add(new Student() { Name = "张sfsfs三", ID = "12345" });
            stuList.Add(new Student() { Name = "李drsfsf四", ID = "34556" });
            stuList.Add(new Student() { Name = "王sfs五", ID = "99999" });
            stuList.Add(new Student() { Name = "赵sfsf是否是", ID = "233334455" });
            stuList.Add(new Student() { Name = "份给我sfsf给我", ID = "777777" });

            InitializeComponent();
        }
    }
}
