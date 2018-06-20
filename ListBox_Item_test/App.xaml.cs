using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace ListBox_Item_test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
