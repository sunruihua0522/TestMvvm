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
using System.Threading.Tasks;
namespace ItemSourceBinding
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
            stuList.Add(new Student() { Name = "张三" ,ID="12345"});
            stuList.Add(new Student() { Name = "李四" , ID = "34556" });
            stuList.Add(new Student() { Name = "王五", ID = "99999" });
            stuList.Add(new Student() { Name = "赵是否是" , ID = "233334455" });
            stuList.Add(new Student() { Name = "份给我给我" , ID = "777777" });

            InitializeComponent();
            //ListBox1.ItemsSource = StuList;
            //ListBox1.DisplayMemberPath = "Name";   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(new Action(() =>
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    if (StuList.Count > 0)
                        StuList.RemoveAt(StuList.Count - 1);
                }));  
            }));
            t.Start();
            
        }
    }
}
