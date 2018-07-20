using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ListBox_Item_test.Converter
{
    public class Age2Brush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            int age = Int16.Parse(value.ToString());
           
            if (age < 30)
                return new SolidColorBrush(Color.FromRgb(255, 0, 0));
            else if (age >= 30 && age < 70)
                return new SolidColorBrush(Color.FromRgb(0, 255, 255));
            else
                return new SolidColorBrush(Color.FromRgb(0, 0, 255));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
