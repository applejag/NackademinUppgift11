using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Threading.Tasks;
using ColorPicker.Models;

namespace ColorPicker.Commands.Database
{
    public class LoadAppendCommand : DatabaseBaseCommand
    {
        public LoadAppendCommand(ObservableCollection<RGBCode> colors) : base(colors)
        { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(ColorDbContext context, object parameter)
        {
            await context.Colors.ForEachAsync(color =>
            {
                _colors.Add(color);
            });
        }
    }
}