using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public abstract class DatabaseBaseCommand : ICommand
    {
        protected readonly SynchronizationContext _synchronizationContext;
        protected readonly ObservableCollection<RGBCode> _colors;

        protected DatabaseBaseCommand(ObservableCollection<RGBCode> colors)
        {
            _synchronizationContext = SynchronizationContext.Current;
            _colors = colors;
        }

        public abstract bool CanExecute(object parameter);
        public abstract Task ExecuteAsync(ColorDbContext context, object parameter);

        public async void Execute(object parameter)
        {
            using (var context = new ColorDbContext())
                await ExecuteAsync(context, parameter);
        }

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            SendToUIThread(() => CanExecuteChanged?.Invoke(this, EventArgs.Empty));
        }

        protected void SendToUIThread(Action action)
        {
            _synchronizationContext.Send(_ => action(), null);
        }
    }
}