using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentControl.ViewModel
{
    public class VM1 : ViewModelBase
    {
        public RelayCommand UI111Command
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Console.WriteLine(1111);
                });
            }
        }
    }
}
