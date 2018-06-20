using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DependencyProperty
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student stu = new Student();
        public MainWindow()
        {
            stu.Name = "Just for test dependencyProperty";
            InitializeComponent();
            object o = DataContext;
            //Binding bind = new Binding("Name") { Source=stu,Mode=BindingMode.TwoWay,UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged};
            //BindingOperations.SetBinding(this, MainWindow.FuncmanagerProperty, bind);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Console.WriteLine(Funcmanager);
            object o = DataContext;
        }

        public string Funcmanager
        {
            get { return (string)GetValue(FuncmanagerProperty); }
            set
            {
                SetValue(FuncmanagerProperty, value);
            }
        }
        public static readonly System.Windows.DependencyProperty FuncmanagerProperty =
             System.Windows.DependencyProperty.Register("Funcmanager", typeof(string), typeof(MainWindow));

        private void UserControl1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
