using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ListBox_Item_test.Converter
{
    public class Age2Image : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Int16 age = Int16.Parse(value.ToString());
            BitmapFrame image =null;
            if (age < 50)
                image = (BitmapFrame)Application.Current.TryFindResource("YY");
            else
                image = (BitmapFrame)Application.Current.TryFindResource("XX");
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
