﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using ColorPicker.Annotations;

namespace ColorPicker.Models
{
    public class RGBCode : INotifyPropertyChanged
    {
        private byte _blue;
        private byte _green;
        private byte _red;

        public byte Red {
            get => _red;
            set { _red = value; OnPropertyChanged(); }
        }

        public byte Green {
            get => _green;
            set { _green = value; OnPropertyChanged(); }
        }

        public byte Blue {
            get => _blue;
            set { _blue = value; OnPropertyChanged(); }
        }

        public RGBCode()
            : this(255, 255, 255)
        { }

        public RGBCode(byte blue, byte green, byte red)
        {
            _blue = blue;
            _green = green;
            _red = red;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}