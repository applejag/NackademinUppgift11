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

            switch (parameter as string)
            {
                case "R":
                case nameof(color.Red):
                    return $"#{color.Red:X2}0000";

                case "G":
                case nameof(color.Green):
                    return $"#00{color.Green:X2}00";

                case "B":
                case nameof(color.Blue):
                    return $"#0000{color.Blue:X2}";

                default:
                    return $"#{color.Red:X2}{color.Green:X2}{color.Blue:X2}";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}