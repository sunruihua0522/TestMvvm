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
using ContentControl.Model;
namespace ContentControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window ,INotifyPropertyChanged
    {
        private MyModel _model = new MyModel();
        private MyModel _model1 = new MyModel() { SelectUi1 = true };

        public MyModel Model
        {
            set
            {
                if(_model!=value)
                { 
                    _model = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Model"));
                }
            }
            get { return _model; }
        }
        public MainWindow()
        {
            
            InitializeComponent();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model = new MyModel() { SelectUi1 = true };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Model = new MyModel() { SelectUi1 = false };
        }
    }
}
