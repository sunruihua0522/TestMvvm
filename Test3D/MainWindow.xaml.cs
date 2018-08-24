using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    public partial class MainWindow : DXRibbonWindow, INotifyPropertyChanged
    {
        private int k = 0;
        private string count = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Point3D> MyData { get; set; }
        public ObservableCollection<Point> MyData2D { get; set; }
        private int _minData = 0;
        public MainWindow()
        {
   
            MyData = new ObservableCollection<Point3D>();
            MyData2D = new ObservableCollection<Point>();
            InitializeComponent();
            CancellationTokenSource cts = new CancellationTokenSource();
            Task t = new Task(()=> {
                Random r = new Random();
                for (int i = 0; i < 10; i++)
                {
                    k = 0;
                    for (double x = -Math.PI; x < Math.PI; x += 0.1)
                    {
                        for (double y = -Math.PI; y < Math.PI; y += 0.1)
                        {
                            Thread.Sleep(200);
                            Application.Current.Dispatcher.Invoke(()=> {
                                MyData.Add(new Point3D(x, y, Math.Sin(x * /*r.NextDouble()*/1) * Math.Cos(y)));
                                if (k++ % 3 == 0)
                                    MyData2D.Add(new Point(x * r.NextDouble() + 30, y * r.NextDouble() + 100));

                                Count = k.ToString();
                            });
                           
                        }
                    }
                    MyData.Clear();
                    MyData2D.Clear();
                }
            },cts.Token);
            t.Start();
           
        }

        public string Count
        {
            get { return count; }
            set
            {
                if (count != value)
                {
                    count = value;
                    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Count"));
                }
            }
        }
        public int MinData
        {
            get { return _minData; }
            set
            {
                if (_minData != value)
                {
                    _minData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinData"));
                }
            }
        }

        ~MainWindow()
        {
            MyData.Clear();
            MyData = null;
            MyData2D.Clear();
            MyData2D = null;
        }

        private void ChartControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MinData += 10;
            if (MinData >= 90)
                MinData = 20;
        }
    }
}
