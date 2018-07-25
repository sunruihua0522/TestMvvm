using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ContentControl.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private ViewModelBase vm=null;
        private VM1 vm1=new VM1();
        private VM2 vm2 = new VM2();

        public MainViewModel()
        {

        }
        public ViewModelBase VM
        {
            get
            {
                return vm;
            }
            set
            {
                if (vm != value)
                {
                    vm = value;
                    RaisePropertyChanged();
                }
            }
        }
        public RelayCommand<string> ChooseUIComand
        {
            get { return new RelayCommand<string>(str=> {
                if (str == "UI1")
                {
                    VM = vm1;
                }
                else if (str == "UI2")
                {
                    VM = vm2;
                }
            }); }
        }
    }
}