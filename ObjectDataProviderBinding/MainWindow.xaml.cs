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
using HalconDotNet;
using System.Threading.Tasks;
using System.Threading;
namespace ObjectDataProviderBinding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cts = null;
        private Calu cal = new Calu();
        private Task task = null;
        private HObject ho_Image = null;
        private bool bChanged = false;
        private long xx = 0;
        private long yy = 0;
        private object _lock = new object();
        
        HTuple imageWidth, imageHeight;
        HTuple hv_AcqHandle;

        private AutoResetEvent grabEvent = new AutoResetEvent(false);
        private int nInternal=1000;
        private HObject TempImage=new HObject();
        public MainWindow()
        {
            InitializeComponent();
            SetBinding();
         
        }
        private void SetBinding()
        {
            ConvertModels convert = new ConvertModels();
            ObjectDataProvider odp = new ObjectDataProvider();
            ValidRule rule = new ValidRule();
 
            odp.ObjectInstance = cal;
            odp.MethodName = "Add";
            odp.MethodParameters.Add(0);    //由参数自动选择使用的是哪个重载函数
            odp.MethodParameters.Add(0);


            Binding bind = new Binding("MethodParameters[0]") { Source = odp, BindsDirectlyToSource = true, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Converter = convert };
            bind.ValidationRules.Add(rule);     
            bind.NotifyOnValidationError = true;
            Binding bind1 = new Binding("MethodParameters[1]") { Source = odp, BindsDirectlyToSource = true, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Converter = convert };
            //bind1.ValidationRules.Add(rule);
            bind1.NotifyOnValidationError = true;
            Binding bind2 = new Binding(".") { Source = odp };
            TextBox1.SetBinding(TextBox.TextProperty, bind);    //BindsDirectlyToSource指示绑定的方向
            TextBox2.SetBinding(TextBox.TextProperty, bind1);
            TextBox3.SetBinding(TextBox.TextProperty, bind2);

            //1、ObjcetDataProvider的MethodParameter不是依赖属性，不能作为Binding的目标。
            //2、数据驱动UI理念要求我们尽可能的使用数据对象作为Binding的Source而把UI当做Binding的Target。

            //捕捉校验事件
            Grid1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler((o,args)=> {
              
                //Validation.GetErrors(o as FrameworkElement);
                if(Validation.GetErrors(TextBox1).Count>0)
                    Console.WriteLine("Sender:  "+(args.OriginalSource as FrameworkElement).Name+"    Error:  "+ Validation.GetErrors(TextBox1)[0].ErrorContent);
                if (Validation.GetErrors(TextBox2).Count > 0)
                    Console.WriteLine("Sender:  " + (args.OriginalSource as FrameworkElement).Name + "    Error:  " + Validation.GetErrors(TextBox2)[0].ErrorContent);
            }));
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (task == null || task.Status == TaskStatus.Canceled || task.Status == TaskStatus.RanToCompletion)
            { 
                cts = new CancellationTokenSource();
                task = new Task(ThreadFunc, cts.Token);
                task.Start();
            }

        }
        private void ThreadFunc()
        {
            
            HOperatorSet.GrabImage(out ho_Image, hv_AcqHandle);     //会新生成Image，因为ho_Image初始是为null的，所以GrabImage肯定是内部new了Image
            HOperatorSet.GetImageSize(ho_Image, out HTuple width, out HTuple height);
            ho_Image.Dispose();
            HOperatorSet.SetPart(halconCtrl.HalconWindow, 0, 0, height, width);
            HOperatorSet.SetLineWidth(halconCtrl.HalconWindow, 5);
            HTuple ss = halconCtrl.HalconWindow;
            HOperatorSet.SetColor(halconCtrl.HalconWindow, "red");
            HOperatorSet.GenRegionLine(out HObject reg, height / 2, 0, height / 2, width);
            HOperatorSet.GenRegionLine(out HObject reg1, 0, width / 2, height, width / 2);
            HOperatorSet.GenRectangle1(out HObject rect, height / 2 - 50, width / 2 - 50, height / 2 + 50, width / 2 + 50);
            HOperatorSet.SetDraw(halconCtrl.HalconWindow, "margin");
            while (!cts.Token.IsCancellationRequested)
            {
                lock (_lock)
                {
                    bool ret = grabEvent.WaitOne(50);
                    if (ret)
                        continue;
                    nInternal = 200;
                    if (TempImage != null)
                    {
                        TempImage.Dispose();
                        TempImage = null;
                    }
                    HOperatorSet.GrabImage(out ho_Image, hv_AcqHandle);
                    TempImage = ho_Image.SelectObj(1);
                    ho_Image.Dispose();
                    HOperatorSet.GenEmptyObj(out HObject region);
                    HOperatorSet.DispObj(TempImage, halconCtrl.HalconWindow);
                    //HOperatorSet.DispObj(ho_Image, halconCtrl.HalconWindow);
                    HOperatorSet.DispObj(reg, halconCtrl.HalconWindow);
                    HOperatorSet.DispObj(reg1, halconCtrl.HalconWindow);
                    HOperatorSet.DispObj(rect, halconCtrl.HalconWindow);

                }
                //break ;
            }
            reg.Dispose();
            reg1.Dispose();
            rect.Dispose();
        
        }

        private void TextBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(cts!=null)
                cts.Cancel();   
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb",
              -1, "false", "default", "Integrated Camera", 0, -1, out hv_AcqHandle);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
                task.Wait();
                cts = null;
                task = null;
            }
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
        }

        private void halconCtrl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            lock (_lock)
            {
                grabEvent.Set();          
            }        
        }
        private void ReadPicture(String ImagePath="")
        {

            string strImagPath;
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            //openFileDialog1.Filter = "|PNG文件|*.png*|BMP文件|*.bmp*|JPEG文件|*.jpg*";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == true)
            {
                strImagPath = openFileDialog1.FileName;
                HOperatorSet.GenEmptyObj(out ho_Image);
                HOperatorSet.ReadImage(out ho_Image, strImagPath);
                HOperatorSet.GetImageSize(ho_Image, out imageWidth, out imageHeight);
                HOperatorSet.SetPart(halconCtrl.HalconWindow, 0, 0, imageHeight - 1, imageWidth - 1);
                HOperatorSet.DispObj(ho_Image, halconCtrl.HalconWindow);  
            }

        }
    }
}
