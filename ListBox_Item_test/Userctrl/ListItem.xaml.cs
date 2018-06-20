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
using ListBox_Item_test.Model;
using ListBox_Item_test.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace ListBox_Item_test.Userctrl
{
    /// <summary>
    /// ListItem.xaml 的交互逻辑
    /// </summary>
    public partial class ListItem : UserControl
    {
        private Mymodel VM=null;
        public ListItem()
        {
            InitializeComponent();
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VM = ServiceLocator.Current.GetInstance<Mymodel>();           
            Student stu= DataContext as Student;
            VM.StartTast.Execute(stu.Index);       
        }
    }
}
