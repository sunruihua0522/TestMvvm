using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ObjectDataProviderBinding
{
    public class ConvertModels : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) //源到目标
        {
            double.TryParse(value.ToString(), out double x);
            return x;           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) //目标到源
        {
            double.TryParse(value.ToString(), out double x);
            return x;
        }
    }
}
