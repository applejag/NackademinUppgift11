using System.ComponentModel;
using System.Runtime.CompilerServices;
using ColorPicker.Annotations;
using ColorPicker.Models;

namespace ColorPicker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public RGBCode RgbCode { get; } = new RGBCode();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            RgbCode.PropertyChanged += RgbCodeOnPropertyChanged;
        }

        private void RgbCodeOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(RgbCode));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}