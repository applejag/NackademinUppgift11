using System;
using System.ComponentModel;
using System.Windows.Input;
using ColorPicker.Models;
using ColorPicker.ViewModels;

namespace ColorPicker.Commands
{
    public class RemoveColorCommand : ICommand
    {
        private readonly MainViewModel _model;

        public RemoveColorCommand(MainViewModel model)
        {
            _model = model;
            _model.PropertyChanged += ModelOnPropertyChanged;
        }

        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_model.SelectedColorIndex))
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _model.SelectedColorIndex != -1;
        }

        public void Execute(object parameter)
        {
            _model.ColorList.RemoveAt(_model.SelectedColorIndex);
            _model.SelectedColorIndex = -1;
        }

        public event EventHandler CanExecuteChanged;
    }
}