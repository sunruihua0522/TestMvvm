using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentControl.ViewModel
{
    public class VM2 : ViewModelBase
    {
        public RelayCommand UI222Command
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Console.WriteLine(2222);
                });
            }
        }
    }
}
