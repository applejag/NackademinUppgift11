using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Threading.Tasks;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public class LoadOverwriteCommand : DatabaseBaseCommand
    {
        public LoadOverwriteCommand(ObservableCollection<RGBCode> colors) : base(colors)
        { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(ColorDbContext context, object parameter)
        {
            SendToUIThread(() => _colors.Clear());

            await context.Colors.ForEachAsync(color =>
            {
                SendToUIThread(() => _colors.Add(color));
            });
        }
    }
}