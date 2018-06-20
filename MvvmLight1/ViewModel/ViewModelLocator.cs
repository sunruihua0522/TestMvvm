/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:MvvmLight1.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MvvmLight1.Model;
using System.Windows;

namespace MvvmLight1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
        }



        private RelayCommand _MyCommand;

        public RelayCommand MyCommand
        {
            get
            {
                return _MyCommand
                    ?? (_MyCommand = new RelayCommand(ExecuteMyCommand));
            }
        }

        private void ExecuteMyCommand()
        {

        }

        public const string MyTextPropertyName = "MyText";
        public static int GetMyText(DependencyObject obj)
        {
            return (int)obj.GetValue(MyTextProperty);
        }
        public static void SetMyText(DependencyObject obj, int value)
        {
            obj.SetValue(MyTextProperty, value);
        }
        public static readonly DependencyProperty MyTextProperty = DependencyProperty.RegisterAttached(
            MyTextPropertyName,
            typeof(int),
            typeof(ViewModelLocator),
            new UIPropertyMetadata(0));
    }
}