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
using System.Xml;

namespace XmlBinding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _labelCaption;
        private XmlDataProvider dp;
        public XmlDataProvider DP { set { dp = value;} get { return dp; } }
        public string LabelCaption {
            get { return _labelCaption; }
            set { _labelCaption = value; }
        }
        public MainWindow()
        {
            _labelCaption = "For test Binding";
            //InitializeComponent();
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"C:\Users\Ricky Sun\source\repos\MvvmLight1\XmlBinding\bin\Debug\Student.xml");

            //dp = new XmlDataProvider();
            //dp.Document = doc;

            //dp.XPath = @"StudentList/Student";

            //this.ListView1.DataContext = dp;
            //this.ListView1.SetBinding(ListView.ItemsSourceProperty, new Binding());

        }
    }
}
