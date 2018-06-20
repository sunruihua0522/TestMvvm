using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Ribbon;

namespace Test3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {

        public ObservableCollection<Point3D> MyData { get; set; }
        public MainWindow()
        {
   
            MyData = new ObservableCollection<Point3D>();
       
            InitializeComponent();
            Random r = new Random();
            for (double x = -Math.PI; x < Math.PI; x += 0.1)
            {
                for (double y = -Math.PI; y < Math.PI; y += 0.1)
                {
                    MyData.Add(new Point3D(x, y, Math.Sin(x * r.NextDouble()) * Math.Cos(y)));
                }
            }

        }
    }
}
