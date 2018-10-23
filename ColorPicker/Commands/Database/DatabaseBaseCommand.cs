using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public abstract class DatabaseBaseCommand : ICommand
    {
        protected readonly ObservableCollection<RGBCode> _colors;

        protected DatabaseBaseCommand(ObservableCollection<RGBCode> colors)
        {
            _colors = colors;
        }

        public abstract bool CanExecute(object parameter);
        public abstract Task ExecuteAsync(ColorDbContext context, object parameter);

        public void Execute(object parameter)
        {
            using (var context = new ColorDbContext())
                ExecuteAsync(context, parameter).RunSynchronously();
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}