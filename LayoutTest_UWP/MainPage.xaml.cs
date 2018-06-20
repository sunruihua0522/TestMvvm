using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using LayoutTest_UWP.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace LayoutTest_UWP
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;
        private string CurselString = "Playing";
        public MainPage()
        {
            CurselString = "Playing";
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;

            Loaded += (s, e) =>
            {
                Vm.RunClock();
            };
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Vm.StopClock();
            base.OnNavigatingFrom(e);
        }

        private void btnMenu_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(SecondPage), "Playing");
        }

        private void ListBox_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            
            ListBox Lb = sender as ListBox;
            switch (Lb.SelectedIndex)
            {
                case 0:
                    CurselString = "Playing";
                    MyFrame.Navigate(typeof(SecondPage), "Playing");
                    break;
                case 1:
                    CurselString = "Working";
                    MyFrame.Navigate(typeof(BlankPage1), "Working");
                    break;
                case 2:
                    CurselString = "Flying";
                    MyFrame.Navigate(typeof(Page3),"Flying");
                    break;
                default:
                    break;
            }
            Vm.ListBoxClickCommand.Execute(CurselString);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
                MyFrame.GoBack();
        }
    }
}
