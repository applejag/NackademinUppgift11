using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ColorPicker.Annotations;
using ColorPicker.Commands;
using ColorPicker.Models;

namespace ColorPicker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _selectedColorIndex = -1;

        public RGBCode RgbCode { get; } = new RGBCode();
        public ObservableCollection<RGBCode> ColorList { get; } = new ObservableCollection<RGBCode>
        {
            new RGBCode(174, 17, 65),
            new RGBCode(147, 124, 75),
            new RGBCode(51, 77, 153),
            new RGBCode(129, 229, 46),
        };

        public int SelectedColorIndex {
            get => _selectedColorIndex;
            set { _selectedColorIndex = value; OnPropertyChanged(); }
        }

        public AddColorCommand AddColorCommand { get; }
        public RemoveColorCommand RemoveColorCommand { get; }
        public DatabaseCommands DatabaseCommands { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            AddColorCommand = new AddColorCommand(this);
            RemoveColorCommand = new RemoveColorCommand(this);
            DatabaseCommands = new DatabaseCommands(ColorList);

            RgbCode.PropertyChanged += (o, args) =>
            {
                OnPropertyChanged(nameof(RgbCode));
            };

            ((INotifyPropertyChanged)ColorList).PropertyChanged += (o, args) =>
            {
                OnPropertyChanged(nameof(ColorList));
            };
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}