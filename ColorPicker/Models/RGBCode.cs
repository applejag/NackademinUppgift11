using System.ComponentModel;
using System.Runtime.CompilerServices;
using ColorPicker.Annotations;

namespace ColorPicker.Models
{
    public class RGBCode : INotifyPropertyChanged
    {
        private byte _blue = 255;
        private byte _green = 255;
        private byte _red = 255;

        public byte Red
        {
            get => _red;
            set { _red = value; OnPropertyChanged(); }
        }

        public byte Green
        {
            get => _green;
            set { _green = value; OnPropertyChanged(); }
        }

        public byte Blue
        {
            get => _blue;
            set { _blue = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}