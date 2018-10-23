using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ColorPicker.Annotations;
using ColorPicker.Models;

namespace ColorPicker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public RGBCode RgbCode { get; } = new RGBCode();
        public RGBCode ForegroundRgbCode => GetForegroundRgbCode();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            RgbCode.PropertyChanged += RgbCodeOnPropertyChanged;
        }

        private RGBCode GetForegroundRgbCode()
        {
            float r = RgbCode.Red / 255f;
            float g = RgbCode.Green / 255f;
            float b = RgbCode.Blue / 255f;
            float brightness = (0.2126f * r + 0.7152f * g + 0.0722f * b);

            return brightness < 0.75f
                ? new RGBCode(255,255,255)
                : new RGBCode(47, 79, 79);
        }

        private void RgbCodeOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(RgbCode));
            OnPropertyChanged(nameof(ForegroundRgbCode));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}