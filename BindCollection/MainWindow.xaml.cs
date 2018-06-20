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
using BindCollection.Modle;
namespace BindCollection
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Modle.Modle mode=new Modle.Modle();
       
        public MainWindow()
        {
            InitializeComponent();
            TextBox1.SetBinding(TextBox.TextProperty, new Binding ("[0]"){Source= mode.NamesList, Mode=BindingMode.OneWay});
            TextBox2.SetBinding(TextBox.TextProperty, new Binding("[2]") { Source = mode.NamesList, Mode = BindingMode.OneWay });
            TextBox3.SetBinding(TextBox.TextProperty, new Binding("[2].Length") { Source = mode.NamesList, Mode = BindingMode.OneWay });

            TextBox4.SetBinding(TextBox.TextProperty, new Binding("[0]") { Source = mode.Ctry.Province[0].City[0].Person[0].name, Mode = BindingMode.OneWay });
            TextBox5.SetBinding(TextBox.TextProperty, new Binding("[1]") { Source = mode.Ctry.Province[0].City[0].Person[0].name, Mode = BindingMode.OneWay });
            TextBox6.SetBinding(TextBox.TextProperty, new Binding("[2]") { Source = mode.Ctry.Province[0].City[0].Person[0].name, Mode = BindingMode.OneWay });
        }
    }
}
