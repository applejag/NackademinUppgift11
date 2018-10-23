using System;
using System.Globalization;
using System.Windows.Data;
using ColorPicker.Models;

namespace ColorPicker.Converters
{
    public class RGB2RGBConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is RGBCode color))
                throw new NotSupportedException();
            
            return $"rgb({color.Red}, {color.Green}, {color.Blue})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}