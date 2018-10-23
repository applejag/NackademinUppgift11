using System;
using System.Globalization;
using System.Windows.Data;
using ColorPicker.Models;

namespace ColorPicker.Converters
{
    public class RGB2HTMLConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is RGBCode color))
                throw new NotSupportedException();

            return $"#{color.Red:X2}{color.Green:X2}{color.Blue:X2}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}