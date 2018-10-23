using System;
using System.Windows.Input;
using ColorPicker.Models;
using ColorPicker.ViewModels;

namespace ColorPicker.Commands
{
    public class AddColorCommand : ICommand
    {
        private readonly MainViewModel _model;

        public AddColorCommand(MainViewModel model)
        {
            _model = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _model.ColorList.Add(new RGBCode(_model.RgbCode.Red, _model.RgbCode.Green, _model.RgbCode.Blue));
        }

        public event EventHandler CanExecuteChanged;
    }
}