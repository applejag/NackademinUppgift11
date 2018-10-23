using System;
using System.Globalization;
using System.Windows.Data;
using ColorPicker.Models;

namespace ColorPicker.Converters
{
    public class RGB2HexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is RGBCode color))
                throw new NotSupportedException();

            switch (parameter as string)
            {
                case "Foreground":
                    color = GetForegroundRgbCode(color);
                    goto default;

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
        
        private RGBCode GetForegroundRgbCode(RGBCode color)
        {
            float r = color.Red / 255f;
            float g = color.Green / 255f;
            float b = color.Blue / 255f;
            float brightness = (0.2126f * r + 0.7152f * g + 0.0722f * b);

            return brightness < 0.75f
                ? new RGBCode(255, 255, 255)
                : new RGBCode(47, 79, 79);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}