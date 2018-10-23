using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ColorPicker.Annotations;
using ColorPicker.Models;

namespace ColorPicker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _selectedColorIndex;

        public RGBCode RgbCode { get; } = new RGBCode();
        public RGBCode ForegroundRgbCode => GetForegroundRgbCode();
        public ObservableCollection<RGBCode> ColorList { get; } = new ObservableCollection<RGBCode>();

        public int SelectedColorIndex {
            get => _selectedColorIndex;
            set { _selectedColorIndex = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            RgbCode.PropertyChanged += (o, args) =>
            {
                OnPropertyChanged(nameof(RgbCode));
                OnPropertyChanged(nameof(ForegroundRgbCode));
            };

            ((INotifyPropertyChanged)ColorList).PropertyChanged += (o, args) =>
            {
                OnPropertyChanged(nameof(ColorList));
            };
        }

        private RGBCode GetForegroundRgbCode()
        {
            float r = RgbCode.Red / 255f;
            float g = RgbCode.Green / 255f;
            float b = RgbCode.Blue / 255f;
            float brightness = (0.2126f * r + 0.7152f * g + 0.0722f * b);

            return brightness < 0.75f
                ? new RGBCode(255, 255, 255)
                : new RGBCode(47, 79, 79);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}